using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using pebble_api_dotnet;
using pebble_api_dotnet.Layouts;
using Xunit;
using Action = pebble_api_dotnet.Action;

namespace pebble_api_dotnet_tests
{
    public class UserTests
    {
        public static string APIKey = "SBd83edluj648wbw9sfwg6cq6cj3ha6p";
        public static string userToken = "SBes92jmsocz1kb5yyotx1z59rja2f1v";

        [Fact]
        public async Task SendToUser_GenericLayout()
        {
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

            Assert.True(result.Success);
        }

        [Fact]
        public async Task SendToUser_GenericLayout_Action()
        {
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

            Assert.True(result.Success);
        }

        [Fact]
        public async Task SendToUser_GenericLayout_GenericReminder()
        {
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

            Assert.True(result.Success);
        }


        [Fact]
        public async Task SendToUser_CalendarLayout_Past()
        {
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

            Assert.True(result.Success);
        }

        [Fact]
        public async Task SendToUser_CalendarLayout_Future()
        {
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

            Assert.True(result.Success);
        }



        [Fact]
        public async Task SendToUser_WeatherLayout()
        {
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

            Assert.True(result.Success);
        }

        [Fact]
        public async Task SendToUser_SportsLayout()
        {
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
                    //TinyIcon = Icons.Sports.Hockey,
                    //LargeIcon = Icons.Sports.Hockey, 
                   
                },
            });
            Assert.True(result.Success);
        }
    }
}