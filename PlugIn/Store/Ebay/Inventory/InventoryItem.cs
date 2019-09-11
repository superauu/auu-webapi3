//using System;
//using System.Collections.Generic;
//
//namespace Auu.PlugIn.Store.EbayApi.Inventory
//{
//    public static class InventoryItem
//    {
//        public static void AddItem(CstItemEbay ebayItem)
//        {
//            var request = new AddFixedPriceItemRequestType() { Item = new ItemType() };
//            var eBayItemApi = request.Item;
//            CstItem item = ebayItem.CstItem;
//
//            eBayItemApi.Quantity = ebayItem.Quantity ?? item.Quantity;
//            eBayItemApi.QuantitySpecified = true;
//            eBayItemApi.StartPrice = new AmountType()
//            {
//                currencyID = (CurrencyCodeType) item.CurrencyCode,
//                Value = ebayItem.StartPrice ?? (double) item.SellingPrice
//            };
//
//            eBayItemApi.SKU = item.Sku;
//            eBayItemApi.Title = ebayItem.Title ?? item.ShortDescription;
//            eBayItemApi.ConditionDescription = item.ConditionDescription;
//            eBayItemApi.Country = (CountryCodeType) (ebayItem.CountryCode ?? item.CountryCode);
//            eBayItemApi.CountrySpecified = true;
//            eBayItemApi.Currency = (CurrencyCodeType) (ebayItem.CurrencyCode ?? item.CurrencyCode);
//            eBayItemApi.CurrencySpecified = true;
//            eBayItemApi.ConditionID = ebayItem.ConditionId;
//            eBayItemApi.ConditionIDSpecified = true;
//            eBayItemApi.Description = item.Description;
//            if (item.DigitalDelivery != null)
//            {
//                eBayItemApi.DigitalGoodInfo = new DigitalGoodInfoType()
//                {
//                    DigitalDelivery = Convert.ToBoolean(item.DigitalDelivery),
//                    DigitalDeliverySpecified = true,
//                };
//            }
//
//            if (ebayItem.DisableBuyerRequirements != null)
//            {
//                eBayItemApi.DisableBuyerRequirements = Convert.ToBoolean(ebayItem.DisableBuyerRequirements);
//                eBayItemApi.DisableBuyerRequirementsSpecified = true;
//            }
//
//            eBayItemApi.DispatchTimeMax = ebayItem.DispatchTimeMax ?? 1;
//            eBayItemApi.DispatchTimeMaxSpecified = true;
//
//            if (ebayItem.EBayPlus != null)
//            {
//                eBayItemApi.eBayPlus = Convert.ToBoolean(ebayItem.EBayPlus);
//                eBayItemApi.eBayPlusSpecified = true;
//            }
//
//            //eBayItem.DiscountPriceInfo = new DiscountPriceInfoType()
//            //{
//            //    OriginalRetailPrice = new AmountType()
//            //    {
//            //        Value = item.OriginalRetailPrice ?? 0,
//            //    }
//            //};
//
//            eBayItemApi.Location = item.Location;
//            eBayItemApi.ListingDuration = ebayItem.ListingDuration.ToString();
//            eBayItemApi.PayPalEmailAddress = ebayItem.PayPalEmailAddress;
//            eBayItemApi.EligibleForPickupDropOff = Convert.ToBoolean(ebayItem.EligibleForPickupInStore);
//            eBayItemApi.EligibleForPickupDropOffSpecified = true;
//            eBayItemApi.PrimaryCategory = new CategoryType()
//            {
//                CategoryID = item.Category.CstCategoryEbay.ElementAt(0).EbayCategoryCode,
//            };
//
//            eBayItemApi.ProductListingDetails = new ProductListingDetailsType()
//            {
//                BrandMPN = new BrandMPNType() {Brand = item.Brand.BrandName, MPN = item.Mpn},
//                EAN = item.Ean,
//                ISBN = item.Isbn,
//                UPC = item.Upc,
//            };
//            eBayItemApi.ListingType = ListingTypeCodeType.FixedPriceItem;
//            eBayItemApi.ListingTypeSpecified = true;
//            if (ebayItem.IncludeeBayProductDetails != null)
//            {
//                eBayItemApi.ProductListingDetails.IncludeeBayProductDetails =
//                    Convert.ToBoolean(ebayItem.IncludeeBayProductDetails);
//                eBayItemApi.ProductListingDetails.IncludeeBayProductDetailsSpecified = true;
//            }
//            if (ebayItem.IncludeStockPhotoUrl != null)
//            {
//                eBayItemApi.ProductListingDetails.IncludeStockPhotoURL =
//                    Convert.ToBoolean(ebayItem.IncludeStockPhotoUrl);
//                eBayItemApi.ProductListingDetails.IncludeStockPhotoURLSpecified = true;
//            }
//
//            eBayItemApi.PictureDetails = new PictureDetailsType()
//                {
//                    PictureURL = item.CstItemPictureDetails.Select(p => p.PictureUrl).ToArray()
//                };
//
//            eBayItemApi.Site = (SiteCodeType)(ebayItem.SiteCode?? item.SiteCode);
//            eBayItemApi.SiteSpecified = true;
//            eBayItemApi.ShippingDetails = new ShippingDetailsType()
//            {
//                ShippingType = (ShippingTypeCodeType)ebayItem.ShippingCode,
//                ShippingTypeSpecified = true,
//            };
//            if (ebayItem.CstItemEbayShippingServiceOptions != null && ebayItem.CstItemEbayShippingServiceOptions.Count > 0)
//            {
//                eBayItemApi.ShippingDetails.ShippingServiceOptions = ebayItem.CstItemEbayShippingServiceOptions.Select(ss =>
//                {
//                    return new ShippingServiceOptionsType()
//                    {
//                        ShippingService = ss.ShippingServiceCode.ToString(),
//                        FreeShipping = Convert.ToBoolean(ss.FreeShipping),
//                        FreeShippingSpecified = true,
//                        ShippingServicePriority = ss.ShippingServicePriority ?? 0,
//                        ShippingServicePrioritySpecified = true
//                    };
//                }).ToArray();
//            }
//
//            //var list = ebayItem.CstItemEbayPaymentMethod.Select(p =>
//            //{
//            //    if (Enum.TryParse(p.PaymentMethodCode, out BuyerPaymentMethodCodeType x))
//            //    {
//            //        return x;
//            //    }
//            //    else
//            //    {
//            //        return BuyerPaymentMethodCodeType.PayPal;
//            //    }
//            //}).ToArray();
//            //eBayItem.PaymentMethods = list;//new BuyerPaymentMethodCodeType[1] {BuyerPaymentMethodCodeType.PayPal};
//
//            eBayItemApi.ReturnPolicy = new ReturnPolicyType()
//            {
//                ReturnsAcceptedOption = ebayItem.ReturnsAcceptedOptionsCode.ToString(),
//                ShippingCostPaidByOption = ebayItem.ShippingCostPaidByOptionsCode.ToString(),
//            };
//
//            var response =
//                EbayCommon.SendTradingApiRequest
//                    <AddFixedPriceItemRequestType, AddFixedPriceItemResponseType>(request, ebayItem.SysEbayAccount);
//
//            //ToDo: Set Fee and Item ID
//            if (response.Ack == AckCodeType.Success)
//            {
//                ebayItem.EbayItemId = response.ItemID;
//                ebayItem.EndTime = response.EndTime;
//                ebayItem.StartTime = response.StartTime;
//                ebayItem.CstItemEbayFee = new List<CstItemEbayFee>();
//                foreach (var feeApi in response.Fees)
//                {
//                    CstItemEbayFee fee = new CstItemEbayFee()
//                    {
//                        FeeName = feeApi.Name,
//                        FeeValue = feeApi.Fee.Value,
//                        FeeCurrencyId = (Models.System.CurrencyCodeType) feeApi.Fee.currencyID,
//                    };
//                    ebayItem.CstItemEbayFee.Add(fee);
//                }
//            }
//        }
//
//
//
//        //        public const string Url = "https://api.ebay.com/sell/inventory/v1/inventory_item/";
//        //        public const string Url2 = "https://api.ebay.com/sell/inventory/v1/inventory_item?limit={0}&offset={1}";
//        //
//        //        public static string RandomSku()
//        //        {
//        //            return Encrypt.Md5(Guid.NewGuid().ToString());
//        //        }
//        //        public static void CreateOrReplaceInventoryItem(string email,CreateInventoryRequest data,string sku)
//        //        {
//        //            var token = Token.GetUserToken(email);
//        //            var headers = RequestComponents.BuildCommonHeader(token);
//        //            var res = Http.HttpPutJson(Url + sku, headers, Json.GetJson(data));
//        //            if (res.Length > 0)
//        //            {
//        //                var err = Json.GetObject<Error>(res);
//        //                if (err != null)
//        //                {
//        //                    if (err.errors != null && err.errors.Count > 0)
//        //                    {
//        //                        throw new Exception(err.errors[0].message);
//        //                    }
//        //                }
//        //                
//        //                throw new Exception(res);
//        //            }
//        //        }
//        //
//        //        public static GetInventoryResponse GetInventoryItems(string email, int limit = 50, int offset = 0)
//        //        {
//        //            string url = string.Format(Url2, limit.ToString(), offset.ToString());
//        //            var token = Token.GetUserToken(email);
//        //            var headers = RequestComponents.BuildCommonHeader(token);
//        //            var res = Http.HttpGet(url, headers);
//        //            return Json.GetObject<GetInventoryResponse>(res);
//        //        }
//        //
//        //        public static GetSingleInventoryResponse GetInventoryItem(string email,string sku)
//        //        {
//        //            var token = Token.GetUserToken(email);
//        //            var headers = RequestComponents.BuildCommonHeader(token);
//        //            var res = Http.HttpGet(Url + sku, headers);
//        //            return Json.GetObject<GetSingleInventoryResponse>(res);
//        //        }
//        //        
//        //        public static void DeleteInventory(string email,string sku)
//        //        {
//        //            var token = Token.GetUserToken(email);
//        //            var headers = RequestComponents.BuildCommonHeader(token);
//        //            var res = Http.HttpDelete(Url + sku, headers);
//        //            if (res.Length > 0)
//        //            {
//        //                var err = Json.GetObject<Error>(res);
//        //                if (err != null)
//        //                {
//        //                    if (err.errors != null && err.errors.Count > 0)
//        //                    {
//        //                        throw new Exception(err.errors[0].message);
//        //                    }
//        //                }
//        //                
//        //                throw new Exception(res);
//        //            }
//        //        }
//    }
//}