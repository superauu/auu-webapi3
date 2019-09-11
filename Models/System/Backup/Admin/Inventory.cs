using System.Collections.Generic;

namespace Auu.Models.System.Backup.Admin
{
    public class FulfillmentTime
    {
        /// <summary>
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// </summary>
        public string value { get; set; }
    }

    public class PickupAtLocationAvailabilityItem
    {
        /// <summary>
        /// </summary>
        public string availabilityType { get; set; }

        /// <summary>
        /// </summary>
        public FulfillmentTime fulfillmentTime { get; set; }

        /// <summary>
        /// </summary>
        public string merchantLocationKey { get; set; }

        /// <summary>
        /// </summary>
        public string quantity { get; set; }
    }

    public class ShipToLocationAvailability
    {
        /// <summary>
        /// </summary>
        public string quantity { get; set; }
    }

    public class Availability
    {
        /// <summary>
        /// </summary>
        public List<PickupAtLocationAvailabilityItem> pickupAtLocationAvailability { get; set; }

        /// <summary>
        /// </summary>
        public ShipToLocationAvailability shipToLocationAvailability { get; set; }
    }

    public class Dimensions
    {
        /// <summary>
        /// </summary>
        public string height { get; set; }

        /// <summary>
        /// </summary>
        public string length { get; set; }

        /// <summary>
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// </summary>
        public string width { get; set; }
    }

    public class Weight
    {
        /// <summary>
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// </summary>
        public string value { get; set; }
    }

    public class PackageWeightAndSize
    {
        /// <summary>
        /// </summary>
        public Dimensions dimensions { get; set; }

        /// <summary>
        /// </summary>
        public string packageType { get; set; }

        /// <summary>
        /// </summary>
        public Weight weight { get; set; }
    }

    public class Product
    {
        /// <summary>
        /// </summary>
        public string aspects { get; set; }

        /// <summary>
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// </summary>
        public List<string> imageUrls { get; set; }

        /// <summary>
        /// </summary>
        public string mpn { get; set; }

        /// <summary>
        /// </summary>
        public string subtitle { get; set; }

        /// <summary>
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// </summary>
        public List<string> isbn { get; set; }

        /// <summary>
        /// </summary>
        public List<string> upc { get; set; }

        /// <summary>
        /// </summary>
        public List<string> ean { get; set; }

        /// <summary>
        /// </summary>
        public string epid { get; set; }
    }

    public class CreateInventoryRequest
    {
        /// <summary>
        /// </summary>
        public Availability availability { get; set; }

        /// <summary>
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// </summary>
        public string conditionDescription { get; set; }

        /// <summary>
        /// </summary>
        public PackageWeightAndSize packageWeightAndSize { get; set; }

        /// <summary>
        /// </summary>
        public Product product { get; set; }
    }


    /////////////

    public class InventoryItemsItem
    {
        /// <summary>
        /// </summary>
        public Availability availability { get; set; }

        /// <summary>
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// </summary>
        public string conditionDescription { get; set; }

        /// <summary>
        /// </summary>
        public PackageWeightAndSize packageWeightAndSize { get; set; }

        /// <summary>
        /// </summary>
        public Product product { get; set; }

        /// <summary>
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// </summary>
        public string locale { get; set; }

        /// <summary>
        /// </summary>
        public List<string> groupIds { get; set; }

        /// <summary>
        /// </summary>
        public List<string> inventoryItemGroupKeys { get; set; }
    }

    public class GetInventoryResponse
    {
        /// <summary>
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// </summary>
        public List<InventoryItemsItem> inventoryItems { get; set; }

        /// <summary>
        /// </summary>
        public string next { get; set; }

        /// <summary>
        /// </summary>
        public string limit { get; set; }

        /// <summary>
        /// </summary>
        public string prev { get; set; }

        /// <summary>
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// </summary>
        public string total { get; set; }
    }


    public class GetSingleInventoryResponse
    {
        /// <summary>
        /// </summary>
        public Availability availability { get; set; }

        /// <summary>
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// </summary>
        public string conditionDescription { get; set; }

        /// <summary>
        /// </summary>
        public PackageWeightAndSize packageWeightAndSize { get; set; }

        /// <summary>
        /// </summary>
        public Product product { get; set; }

        /// <summary>
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// </summary>
        public string locale { get; set; }

        /// <summary>
        /// </summary>
        public List<string> groupIds { get; set; }

        /// <summary>
        /// </summary>
        public List<string> inventoryItemGroupKeys { get; set; }
    }
}