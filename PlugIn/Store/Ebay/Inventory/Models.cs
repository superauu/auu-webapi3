using System.Collections.Generic;

namespace Auu.PlugIn.Store.EbayApi.Inventory
{
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        public string addressLine1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string addressLine2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string county { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string postalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string stateOrProvince { get; set; }
    }

    public class GeoCoordinates
    {
        /// <summary>
        /// 
        /// </summary>
        public string latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string longitude { get; set; }
    }

    public class Location2
    {
        /// <summary>
        /// 
        /// </summary>
        public Address address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GeoCoordinates geoCoordinates { get; set; }
    }
    public class Location
    {
        /// <summary>
        /// 
        /// </summary>
        public Address address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GeoCoordinates geoCoordinates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationId { get; set; }
    }

    public class IntervalsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string close { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string open { get; set; }
    }

    public class OperatingHoursItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string dayOfWeekEnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IntervalsItem> intervals { get; set; }
    }

    public class SpecialHoursItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IntervalsItem> intervals { get; set; }
    }

    public class LocationsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationAdditionalInformation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationInstructions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> locationTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationWebUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string merchantLocationKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string merchantLocationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<OperatingHoursItem> operatingHours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SpecialHoursItem> specialHours { get; set; }
    }
    
    public class LocationsItem2
    {
        /// <summary>
        /// 
        /// </summary>
        public Location2 location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationAdditionalInformation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationInstructions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> locationTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string locationWebUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string merchantLocationKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string merchantLocationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<OperatingHoursItem> operatingHours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SpecialHoursItem> specialHours { get; set; }
    }

    public class GetInventoryLocationsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string limit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<LocationsItem> locations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string next { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string offset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string prev { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string total { get; set; }
    }
    
    public class ErrorsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int errorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }

    public class Error
    {
        /// <summary>
        /// 
        /// </summary>
        public List <ErrorsItem > errors { get; set; }
    }
}