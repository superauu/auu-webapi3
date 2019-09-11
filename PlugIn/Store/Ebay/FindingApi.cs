using System.Collections.Generic;
using Auu.Framework.Common;

namespace Auu.PlugIn.Store.EbayApi
{
    public static class FindingApi
    {
        private const string Url = "http://svcs.ebay.com/services/search/FindingService/v1";

        public static FindItemsByKeywordsResult FindItemsByKeywords(string keyword)
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                {"OPERATION-NAME", "findItemsByKeywords"},
                {"SERVICE-NAME", "FindingService"},
                {"SERVICE-VERSION", "1.0.0"},
                {"SECURITY-APPNAME", GlobalVar.EbayAppId},
                {"RESPONSE-DATA-FORMAT", "JSON"},
                {"keywords", Encrypt.UrlEncode(keyword)}
            };
            return Json.GetObject<FindItemsByKeywordsResult>(Http.HttpGet(Url, null, param));
        }
    }

    #region 查询返回结果的实体类
    public class PrimaryCategoryItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> categoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> categoryName { get; set; }
    }

    public class ProductIdItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string @type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string __value__ { get; set; }
    }

    public class ShippingServiceCostItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string @currencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string __value__ { get; set; }
    }

    public class ShippingInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ShippingServiceCostItem> shippingServiceCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> shippingType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> shipToLocations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> expeditedShipping { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> oneDayShippingAvailable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> handlingTime { get; set; }
    }

    public class CurrentPriceItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string @currencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string __value__ { get; set; }
    }

    public class ConvertedCurrentPriceItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string @currencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string __value__ { get; set; }
    }

    public class SellingStatusItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<CurrentPriceItem> currentPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ConvertedCurrentPriceItem> convertedCurrentPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> sellingState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> timeLeft { get; set; }
    }

    public class ListingInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> bestOfferEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> buyItNowAvailable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> startTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> endTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> listingType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> gift { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> watchCount { get; set; }
    }

    public class ConditionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> conditionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> conditionDisplayName { get; set; }
    }

    public class ItemItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> itemId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> globalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> subtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PrimaryCategoryItem> primaryCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> galleryURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> viewItemURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ProductIdItem> productId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> paymentMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> autoPay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ShippingInfoItem> shippingInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SellingStatusItem> sellingStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ListingInfoItem> listingInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> returnsAccepted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ConditionItem> condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> isMultiVariationListing { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> topRatedListing { get; set; }
    }

    public class SearchResultItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string @count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ItemItem> item { get; set; }
    }

    public class PaginationOutputItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> pageNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> entriesPerPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> totalPages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> totalEntries { get; set; }
    }

    public class FindItemsByKeywordsResponseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> ack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SearchResultItem> searchResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PaginationOutputItem> paginationOutput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> itemSearchURL { get; set; }
    }

    public class FindItemsByKeywordsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<FindItemsByKeywordsResponseItem> findItemsByKeywordsResponse { get; set; }
    }
    #endregion
}