//using System;
//using AcSeller8.Framework.Common;
//
//namespace AcSeller8.PlugIn.Store.EbayApi.Inventory
//{
//    public static class GetLocations
//    {
//        public const string Url = "https://api.ebay.com/sell/inventory/v1/location/";
//
//        public static GetInventoryLocationsResponse GetInventoryLocations(string email)
//        {
//            var token = Token.GetUserToken(email);
//            var headers = RequestComponents.BuildCommonHeader(token);
//            var res = Http.HttpGet(Url, headers);
//            return Json.GetObject<GetInventoryLocationsResponse>(res);
//        }
//
//        public static void CreateInventoryLocation(string email,LocationsItem2 location)
//        {
//            var token = Token.GetUserToken(email);
//            var headers = RequestComponents.BuildCommonHeader(token);
//            var res = Http.HttpPostJson(Url + location.name, headers, Json.GetJson(location));
//            if (res.Length > 0)
//            {
//                var err = Json.GetObject<Error>(res);
//                if (err != null)
//                {
//                    if (err.errors != null && err.errors.Count > 0)
//                    {
//                        throw new Exception(err.errors[0].message);
//                    }
//                }
//                
//                throw new Exception(res);
//            }
//        }
//        
//        public static void DeleteInventoryLocation(string email,string locationKey)
//        {
//            var token = Token.GetUserToken(email);
//            var headers = RequestComponents.BuildCommonHeader(token);
//            var res = Http.HttpDelete(Url + locationKey, headers);
//            if (res.Length > 0)
//            {
//                var err = Json.GetObject<Error>(res);
//                if (err != null)
//                {
//                    if (err.errors != null && err.errors.Count > 0)
//                    {
//                        throw new Exception(err.errors[0].message);
//                    }
//                }
//                
//                throw new Exception(res);
//            }
//        }
//        
//        public static void DisableInventoryLocation(string email,string locationKey)
//        {
//            var token = Token.GetUserToken(email);
//            var headers = RequestComponents.BuildCommonHeader(token);
//            var res = Http.HttpPost(Url + locationKey+"/disable", headers);
//            if (res.Length > 0)
//            {
//                var err = Json.GetObject<Error>(res);
//                if (err != null)
//                {
//                    if (err.errors != null && err.errors.Count > 0)
//                    {
//                        throw new Exception(err.errors[0].message);
//                    }
//                }
//                
//                throw new Exception(res);
//            }
//        }
//        
//        public static void EnableInventoryLocation(string email,string locationKey)
//        {
//            var token = Token.GetUserToken(email);
//            var headers = RequestComponents.BuildCommonHeader(token);
//            var res = Http.HttpPost(Url + locationKey+"/enable", headers);
//            if (res.Length > 0)
//            {
//                var err = Json.GetObject<Error>(res);
//                if (err != null)
//                {
//                    if (err.errors != null && err.errors.Count > 0)
//                    {
//                        throw new Exception(err.errors[0].message);
//                    }
//                }
//                
//                throw new Exception(res);
//            }
//        }
//    }
//}