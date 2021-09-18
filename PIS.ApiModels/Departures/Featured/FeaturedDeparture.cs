using System;

namespace PIS.ApiModels.Departures.Featured
{
    public class FeaturedDeparture
    {
        public DecoratedName OperatorName { get; set; }
        public DecoratedName LineName { get; set; }
        
        public string Destination { get; set; }
        
        public DateTime ScheduledDeparture { get; set; }
        public DateTime? ExpectedDeparture { get; set; }
    }
}