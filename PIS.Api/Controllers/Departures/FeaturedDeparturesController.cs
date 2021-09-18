using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PIS.ApiModels;
using PIS.ApiModels.Departures.Featured;

namespace PIS.Api.Controllers.Departures
{
    [Route("v1/Departures/{regionKey}/{stationKey}/Featured")]
    [ApiController]
    public class FeaturedDeparturesController : ControllerBase
    {
        [HttpGet("{groupKey}")]
        public List<FeaturedDestination> GetGroup(string regionKey, string stationKey, string groupKey)
        {
            if (regionKey == "dk" && stationKey == "kbh" && groupKey == "sj")
            {
                return new List<FeaturedDestination>
                {
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Køge Nord",
                        DestinationNote = "",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow.AddMinutes(5), "re", "Næstved", "1234"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(35), DateTime.UtcNow.AddMinutes(45), "ic", "Esbjerg", "816"),
                        }
                    },
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Roskilde",
                        DestinationNote = "",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow.AddMinutes(5), "re", "Næstved", "1234"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(35), DateTime.UtcNow.AddMinutes(45), "re", "Nykøbing Falster", "1423"),
                        }
                    },
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Cph Lufthavn",
                        DestinationNote = "Copenhagen Airport",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow.AddMinutes(5), "re", "Malmö C", "3"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(20), DateTime.UtcNow.AddMinutes(20), "re", "Göteborg C", "4"),
                        }
                    },
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Helsingør",
                        DestinationNote = "",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow.AddMinutes(5), "re", "Helsingør", "1"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(20), null, "re", "Helsingør", "2"),
                        }
                    }
                };

            }
            else
            {
                return new();
            }
        }

        private FeaturedDeparture MakeDeparture(DateTime scheduledDeparture, DateTime? expectedDeparture,
            string lineType, string destination, string lineNumber)
        {
            var operatorName = new DecoratedName
            {
                Text = "DSB",
                BackgroundColor = "rgb(180, 23, 48)",
                TextColor = "#fff"
            };

            return new FeaturedDeparture()
            {
                Destination = destination,
                LineName = MakeLine(lineType, lineNumber),
                OperatorName = operatorName,
                ScheduledDeparture = scheduledDeparture,
                ExpectedDeparture = expectedDeparture,
            };
        }

        private DecoratedName MakeLine(string lineType, string number)
        {
            switch (lineType)
            {
                case "re":
                    return new DecoratedName
                    {
                        BackgroundColor = "rgb(71, 164, 64)",
                        TextColor = "#fff",
                        Text = $"Re {number}"
                    };
                case "ic":
                    return new DecoratedName
                    {
                        BackgroundColor = "rgb(239, 65, 48)",
                        TextColor = "#fff",
                        Text = $"IC {number}"
                    };
                case "icl":
                    return new DecoratedName
                    {
                        BackgroundColor = "rgb(253, 186, 88)",
                        TextColor = "#000",
                        Text = $"ICL {number}"
                    };
                default:
                    return null;
            }
        }
    }
}
