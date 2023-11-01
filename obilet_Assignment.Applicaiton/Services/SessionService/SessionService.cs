﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using obilet_Assignment.Applicaiton.Common;
using obilet_Assignment.Applicaiton.Common.Cache;
using obilet_Assignment.Applicaiton.Common.HttpCall;
using obilet_Assignment.Applicaiton.Configuration;
using obilet_Assignment.Applicaiton.Services.SessionService;
using obilet_Assignment.Applicaiton.Services.SessionService.Request;
using obilet_Assignment.Applicaiton.Services.SessionService.Response;
using System.Net;
using System.Net.Sockets;
using static obilet_Assignment.Applicaiton.Services.SessionService.Request.GetSessionRequest;

namespace obilet_Assignment.Applicaiton.Services.SessionServices
{
    public class SessionService : ISessionService
    {
        private readonly ObiletOptions _obiletOptions;
        private readonly ILogger<SessionService> _logger;
        private readonly ICacheManager _cacheManager;
        private readonly IHttpCall _httpCall;

        public SessionService(IOptions<ObiletOptions> obiletOptions, ICacheManager cacheManager, ILogger<SessionService> logger, IHttpCall httpCall)
        {
            _obiletOptions = obiletOptions.Value;
            _cacheManager = cacheManager;
            _logger = logger;
            _httpCall = httpCall;
        }
        public async Task<GetSessionResponse> GetSesion()
        {
            try
            {
                BrowserData browserData = await _cacheManager.Get<BrowserData>("browser");
                if (browserData == null)
                {
                    return new GetSessionResponse() { Status = "Fail" };
                }

                GetSessionRequest request = new GetSessionRequest
                {
                    Type = _obiletOptions.SessionType,
                    ConnectionInfo = new Connection
                    {
                        IpAddress = GetIpAddress(),
                        Port = _obiletOptions.Port,
                    },
                    BrowserInfo = new Browser
                    {
                        Name = browserData.Name,
                        Version = browserData.Version
                    }
                };

                string ApiUrl = $"{_obiletOptions.ApiUri}{_obiletOptions.GetSession}";
                HttpResponseMessage httpResponse = await _httpCall.PostCall(request, ApiUrl, _obiletOptions.Token);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return new GetSessionResponse() { Status = "Fail" };
                }

                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<GetSessionResponse>(responseContent);

                if (response?.Status == "Success")
                {
                    await _cacheManager.Set("session", response.Data);
                }

                return response ?? new GetSessionResponse() { Status = "Fail" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetSessionResponse metodunda hata alındı.");
                return new GetSessionResponse() { Status = "Fail" };
            }

        }
        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);

            foreach (IPAddress ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress.ToString();
                }
            }

            return string.Empty;
        }
    }
}
