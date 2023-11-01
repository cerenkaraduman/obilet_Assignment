### obilet.com Sr. Full Stack Developer Programming Assignment

Create an ASP.NET MVC or ASP.NET Core MVC application that allows end users to select their desired origin
& destination & departure date and lists available journeys for the specified query.

#### Wireframe & Design
The application consists of two pages<br>
• Index (first wireframe)<br>
• Journey Index (second wireframe)

#### Functional Requirements 
  ##### Application-wide requirements
• All requests made to obilet.com business API should be coded in the MVC application backend (no client
side requests should be made directly to obilet.com business api, any client side requests implemented
should be made to the application backend. )<br>
• A session should be created and maintained for each different end user visiting the application using the
GetSession method of obilet.com business API. (see the API documentation) Each user should use his/her
own session information in the subsequent API requests made by the application on behalf of that user.
   ###### Index
• All possible bus locations available should fetched from the obilet.com business API GetBusLocations
method (see the API documentation) and be listed as available origins and destinations.<br>
• Default valuesfor origin and destination fields should be set according to the default sorting provided
by GetBusLocations method response.<br>
• Default value for the Departure Date field should be tomorrow.<br>
• Users should be able to perform text-based search on origin and destination fields. The search keyword user
enters should be used in order to fetch related bus locations from the obilet.com business API
GetBusLocations method (see the API documentation).<br>
• Users should be able to swap selected origin and destination locations using the swap button shown in
the design.<br>
• Quick selection buttonsfor setting the date to “Today” and “Tomorrow” should setting the value of
the departure date field properly.<br>
• Following validations & limitations should be implemented with respective error messages.
o Users can not select same location as both origin and destination.<br>
o Minimum valid date for departure date is Today.<br>
• Search button should redirect user to the journey index page with the specified origin, destination
and departure date information.<br>
• Last queried origin, destination and departure date values should be stored on client side. Whenever a user
revisits the application, existing origin, destination and departure date values should be set as default
values, if available.<br>
   ###### Journey Index
• Back button should redirect user to the Index page of the application.<br>
• The origin, destination and departure date provided by the user should be passed to the obilet.com
business API GetJourneys method. (see the API documentation)<br>
• Journeys returned by the API response should be sorted by their departure times and displayed to the user.
