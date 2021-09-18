using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PIS.ApiModels;
using PIS.ApiModels.Departures.Featured;

namespace PIS.Api.Controllers.Departures
{
    [Route("v1/Departures/{regionKey}/{stationKey}/Featured")]
    [ApiController]
    [EnableCors]
    public class FeaturedDeparturesController : ControllerBase
    {
        [HttpGet("{groupKey}")]
        public List<FeaturedDestination> GetGroup(string regionKey, string stationKey, string groupKey)
        {
            if (regionKey == "dk" && stationKey == "kbh" && groupKey == "all")
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
                            MakeDeparture(DateTime.UtcNow.AddMinutes(1), DateTime.UtcNow.AddMinutes(1), "re", "Næstved", "1234"),
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
                            MakeDeparture(DateTime.UtcNow.AddMinutes(2), DateTime.UtcNow.AddMinutes(2), "re", "Næstved", "1235"),
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
                            MakeDeparture(DateTime.UtcNow.AddSeconds(30), DateTime.UtcNow.AddSeconds(30), "re", "Malmö C", "3"),
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
                    },
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Fredericia",
                        DestinationNote = "via Odense",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(25), DateTime.UtcNow.AddMinutes(25), "ic", "Aarhus", "998"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(85), DateTime.UtcNow.AddMinutes(85), "icl", "Aalborg via Aarhus", "999"),
                        }
                    },
                    new()
                    {
                        DestinationRegion = "dk",
                        DestinationKey = "",
                        DestinationName = "Kolding",
                        DestinationNote = "via Odense",
                        Departures = new()
                        {
                            MakeDeparture(DateTime.UtcNow.AddMinutes(45), DateTime.UtcNow.AddMinutes(45), "ic", "Esbjerg", "880"),
                            MakeDeparture(DateTime.UtcNow.AddMinutes(105), DateTime.UtcNow.AddMinutes(105), "ic", "Esbjerg", "881"),
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
                Track = "26",
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
