//Author: Nathan Li
//Create Time: Tuesday, 25 June 2019

using System;
using Auu.Framework.DbControllers.Base;
using Auu.Models.System;

namespace Auu.Models.View
{
    public class CstItem:IEntity
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Sku { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Mpn { get; set; }
        public string Ean { get; set; }
        public string Upc { get; set; }
        public string Isbn { get; set; }
        public string ConditionDescription { get; set; }
        public string Warranty { get; set; }
        public int Quantity { get; set; }
        public decimal? Rrp { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal SellingPrice { get; set; }
        public int TaxId { get; set; }
        public string Location { get; set; }
        public CountryCodeType CountryCode { get; set; }
        public CurrencyCodeType CurrencyCode { get; set; }
        public SiteCodeType SiteCode { get; set; }
        public int? HandlingTime { get; set; }
        public byte? DigitalDelivery { get; set; }
        public decimal? ShippingWeight { get; set; }
        public decimal? ShippingLength { get; set; }
        public decimal? ShippingWidth { get; set; }
        public decimal? ShippingHeight { get; set; }
        public string InternalNotes { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}