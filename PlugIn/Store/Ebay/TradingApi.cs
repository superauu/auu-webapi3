namespace Auu.PlugIn.Store.EbayApi
{
    public static class TradingApi
    {
//        private const string Url = "https://api.ebay.com/ws/api.dll";

//        public static GeteBayDetailsResponseType GeteBayDetails(string token)
//        {
//            //先检查redis是否有未过期的可用数据
//            //redis中ebayDetails用来存xml信息，ebayDetailsExpireTime存过期时间
//            if (Redis.Exist("ebayDetailsExpireTime") && Redis.Exist("ebayDetails"))
//            {
//                var et = Redis.Get("ebayDetailsExpireTime");
//                bool isExpire = true;
//                DateTime dt;
//                if (DateTime.TryParse(et, out dt))
//                {
//                    if (dt > DateTime.Now)
//                        isExpire = false;
//                }
//
//                if (!isExpire)
//                {
//                    var xml = Redis.Get("ebayDetails");
//                    var obj = Xml.GetObject<GeteBayDetailsResponseType>(xml);
//                    if (obj != null)
//                    {
//                        return obj;
//                    }
//                }
//            }
//
//            GeteBayDetailsRequestType gdr = new GeteBayDetailsRequestType();
//            EbayCommon.SendTradingApiRequest<GeteBayDetailsResponseType, GeteBayDetailsRequestType>("GeteBayDetails", gdr, token);
//            Redis.Set("ebayDetails", result);
//            //Redis.Set("ebayDetailsExpireTime", DateTime.Now.AddDays(GlobalVar.EbayDetailExpireDays).ToString());
//            return Xml.GetObject<GeteBayDetailsResponseType>(result);
//        }

        public static GetUserResponseType GetUser(string token=null)
        {
            GetUserRequestType gdr = new GetUserRequestType();
            return EbayCommon.SendTradingApiRequest<GetUserResponseType>("GetUser", gdr, token);
        }
    }
}