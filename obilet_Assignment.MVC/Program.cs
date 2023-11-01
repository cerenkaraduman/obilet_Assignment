using obilet_Assignment.Applicaiton.Common.Cache;
using obilet_Assignment.Applicaiton.Common.HttpCall;
using obilet_Assignment.Applicaiton.Configuration;
using obilet_Assignment.Applicaiton.Services.BusService;
using obilet_Assignment.Applicaiton.Services.SessionService;
using obilet_Assignment.Applicaiton.Services.SessionServices;
using obilet_Assignment.MVC.Business;
using obilet_Assignment.MVC.Business.Interface;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Add Serilog
var logger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IBusService, BusService>();
builder.Services.AddTransient<ISessionService, SessionService>();
builder.Services.AddTransient<IHomeBusiness, HomeBusiness>();
builder.Services.AddTransient<IHttpCall, HttpCall>();
builder.Services.AddSingleton<ICacheManager, CacheManager>();
builder.Services.Configure<ObiletOptions>(
   builder.Configuration.GetSection("OBiletOptions"));
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();