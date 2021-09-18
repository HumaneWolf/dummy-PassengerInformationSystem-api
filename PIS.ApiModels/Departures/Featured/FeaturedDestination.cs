using System.Collections.Generic;

namespace PIS.ApiModels.Departures.Featured
{
    public class FeaturedDestination
    {
        public string DestinationRegion { get; set; }
        public string DestinationKey { get; set; }
        
        public string DestinationName { get; set; }
        public string DestinationNote { get; set; }
        
        public List<FeaturedDeparture> Departures { get; set; }
    }
}