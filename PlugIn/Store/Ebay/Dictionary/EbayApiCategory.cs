using System;
using System.Collections.Generic;
using Auu.Models.System;

namespace Auu.PlugIn.Store.EbayApi.Dictionary
{
    public static class EbayApiCategory
    {
        public static string CategorySiteId = "15";

        public static List<EbayCategory> GetEbayCategory(SysEbayAccount account)
        {
            List<EbayCategory> result = new List<EbayCategory>();

            var request = new GetCategoriesRequestType()
            {
                CategorySiteID = CategorySiteId,
                ViewAllNodes = true
            };
            var response =
                EbayCommon.SendTradingApiRequest
                    <GetCategoriesRequestType, GetCategoriesResponseType>(request, account);

            //Transform
            foreach (var ebayCategory in response.CategoryArray)
            {
                var category = new EbayCategory()
                {
                    Code = ebayCategory.CategoryID,
                    CategoryName = ebayCategory.CategoryName,
                    Level = ebayCategory.CategoryLevel,
                    LeafCategory = Convert.ToByte(ebayCategory.LeafCategory),
                };

                if (ebayCategory.CategoryParentID != null && ebayCategory.CategoryParentID.Length > 0)
                {
                    category.ParentCode = ebayCategory.CategoryParentID[0];
                }
                if (ebayCategory.CategoryParentName != null && ebayCategory.CategoryParentName.Length > 0)
                {
                    category.ParentName = ebayCategory.CategoryParentName[0];
                }

                result.Add(category);
            }
            
            return result;
        }


    }
}