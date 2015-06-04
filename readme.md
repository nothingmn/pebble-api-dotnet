pebble-api-dotnet
=================


A PCL C# Library for the Pebble Timeline Watch


Install
----
git clone git@github.com:nothingmn/pebble-api-dotnet.git

A nuget package will be published soon.


Examples
-----

In your C# project, define your global API Key.

```csharp
public static string APIKey = "APIKEY";
```

Launch your app on the watch, and make the API call...
```javascript
  Pebble.getTimelineToken(
    function (token) {
      console.log('My timeline token is ' + token);
      //send the token to the server
      //or send it to your companion app, via some share storage
      //etc..
    },
    function (error) { 
      //handle accordingly
    }
  );
```

Take that token, and push it to your C# application.  For example, if you are planning on sending messages to the watch from a server, make an HTTP call with this token, and the user identifier for your server based application.

Now, on the server, you can use your "userToken" from the client app, and send pins as follows:


**Send a Generic Layout to a User**

```csharp
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Layout = new GenericLayout()
    {
        Title = "Generic Layout",
        Type = LayoutTypes.genericPin,
        SmallIcon = Icons.Notification.Flag
    },
});
```


**Send a Generic Layout with an Action to a User**

```csharp
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Time = DateTime.UtcNow,
    Layout = new GenericLayout()
    {
        Title = "Generic Action Layout",
        Type = LayoutTypes.genericPin,
        SmallIcon = Icons.Notification.Flag
    },
    Actions = new List<Action>()
    {
      new Action()
      {
          Title = "Accept",
          LaunchCode = 1
      },
      new Action()
      {
          Title = "Deny",
          LaunchCode = 2
      }   

    }
});

```



**Send a Generic Layout with a Generic Reminder to a User**

```csharp
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Time = DateTime.UtcNow,
    Layout = new GenericLayout()
    {
        Title = "Generic Reminder Layout",
        Type = LayoutTypes.genericPin,
        SmallIcon = Icons.Notification.Flag,
        Subtitle = "With a reminder"
    },
    Reminders = new List<Reminder>()
    {
        {
            new Reminder()
            {
                Time = DateTime.UtcNow.AddSeconds(-60),
                Layout = new ReminderLayout()
                {
                    Title = "Generic Reminder",
                    LocationName = "West Boardroom",
                    TinyIcon = Icons.Notification.Reminder
                }
            }
        }
    }
});
```    


**Send a Calendar Layout to a User in the past**

```csharp
var AnHourAgo = DateTime.UtcNow.AddHours(-1);
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Time = AnHourAgo,
    Layout = new CalendarLayout()
    {
        Title = "Past Calendar Layout",
        TinyIcon = Icons.Timeline.Calendar,
        LocationName = "East Conference Room",                    
    },
    Duration = TimeSpan.FromHours(1)
});
```


     

**Send a Calendar Layout to a User, for someting in the future**

```csharp
var HourFromNow = DateTime.UtcNow.AddHours(1);
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Time = HourFromNow,
    Layout = new CalendarLayout()
    {
        Title = "Future Calendar Layout",
        TinyIcon = Icons.Timeline.Calendar,
        LocationName = "East Conference Room"
    },
    Duration = TimeSpan.FromHours(1)
});


```



**Send a Weather Layout to a User**

```csharp
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Time = DateTime.UtcNow,
    Layout = new WeatherLayout()
    {
        Title = "Current Weather",
        TinyIcon = Icons.Weather.TimelineSun,
        LargeIcon = Icons.Weather.TimelineSun,
        LocationName = "Vancouver, Canada",
        LastUpdated = DateTime.UtcNow,
        Subtitle = "15/21",
        Body = "Sunny with no chance of rain"
    },
});

```




**Send a Sports Layout to a User**

```csharp
var timeline = new Timeline(APIKey);
var result = await timeline.SendUserPin(userToken, new Pin()
{
    Id = System.Guid.NewGuid().ToString(),
    Layout = new SportsLayout()
    {
        Title = "Canucks Lose, badly",
        NameHome = "VAN",
        NameAway = "CGY",
        ScoreAway = "04",
        ScoreHome = "06",
        SportsGameState = GameStates.InGame,
        RankAway = "12",
        RankHome = "19",
        RecordAway = "02",
        RecordHome = "03",
        Subtitle = "game ended",
        Body = "Loss of the century!",
        LastUpdated = DateTime.UtcNow,
    },
});
```
