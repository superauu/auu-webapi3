using System;
using System.Collections.Generic;
using System.Text;
using Auu.Framework.Common;
using Auu.Framework.Common.Log;
using Auu.Models.System;

namespace Auu.PlugIn.Store.EbayApi
{
    public static class EbayCommon
    {
        private const string Url = "https://api.ebay.com/ws/api.dll";
        private const string RequestTypeSuffix = "RequestType";
        private const string DefaultLanguage = "en_US";
        private static ILogHelper Logger { get; set; }

        public static Dictionary<string, string> BuildTradingApiHeader(string callName,string token)
        {
            var headers = new Dictionary<string, string>
            {
                {"X-EBAY-API-COMPATIBILITY-LEVEL", "1081"},
                {"X-EBAY-API-CALL-NAME", callName},
                {"X-EBAY-API-SITEID", GlobalVar.EbaySiteId},
                {"X-EBAY-API-DETAIL-LEVEL", "0"},
                {"X-EBAY-API-IAF-TOKEN", token},
                {"X-EBAY-API-DEV-NAME", GlobalVar.EbayDevId},
                {"X-EBAY-API-APP-NAME", GlobalVar.EbayAppId},
                {"X-EBAY-API-CERT-NAME", GlobalVar.EbayCertId}
            };
            return headers;
        }

        public static T SendTradingApiRequest<T>(string callName, object request, string token)
            where T : class
        {
            var headers = BuildTradingApiHeader(callName, token);
            string xmlData = Xml.GetXml(request);
            string xmlResult = Http.HttpPost(GlobalVar.EbayTradingApiUrl, headers, null, xmlData);
            var resultEntity = Xml.GetObject<T>(xmlResult);
            return resultEntity;
        }

        public static T2 SendTradingApiRequest<T1, T2>(T1 request, SysEbayAccount account) 
            where T1 : AbstractRequestType
            where T2 : AbstractResponseType
        {
            T2 resultType;
            string systemErrorMsg;
            string userErrorMsg;

            string callName = typeof(T1).Name.Replace(RequestTypeSuffix, "");

            if (request == null || account == null)
            {
                systemErrorMsg = $"SendTradingApi has exception. eBay-Request:{callName}. Parameter is null. ";
                Logger.LogError(systemErrorMsg);

                userErrorMsg = $"Sending the eBay-Request:[{callName}] is failed. Please try it again.";
                throw new Exception(userErrorMsg);
            }

            string token = Token.GetUserToken(account);
            var headers = BuildTradingApiHeader(callName, token);

            //Standard request default settings
            request.ErrorLanguage = request.ErrorLanguage ?? DefaultLanguage;
            request.DetailLevel = request.DetailLevel ?? 
                                  new DetailLevelCodeType[1] {DetailLevelCodeType.ReturnAll};

            try
            {
                string xmlData = Xml.GetXml(request);
                var resultStr = Http.HttpPost(Url, headers, null, xmlData);
                resultType = Xml.GetObject<T2>(resultStr);
            }
            catch (Exception e)
            {
                systemErrorMsg = $"SendTradingApi has exception. eBay-Request:{callName}. " +
                                        $"UserAccount:{account.EbayId}. Exception Message:{e.Message}. " +
                                        $"Inner Message: {e.InnerException?.Message}";
                Logger.LogError(systemErrorMsg);

                userErrorMsg = $"Sending the eBay-Request:[{callName}] is failed. Please try it again.";
                throw new Exception(userErrorMsg);
            }

            if (resultType.Ack == AckCodeType.Failure || resultType.Ack == AckCodeType.PartialFailure)
            {
                StringBuilder errors = new StringBuilder();
                foreach (var errorType in resultType.Errors)
                {
                    errors.Append(errorType.LongMessage).Append(".").AppendLine();
                }
                systemErrorMsg = $"SendTradingApi has failure. eBay-Request:{callName}. " +
                                 $"UserAccount:{account.EbayId}. Failure Message:{errors}. ";
                Logger.LogError(systemErrorMsg);

                userErrorMsg = $"Sending the eBay-Request:[{callName}] is failed. " +
                               $"Failure Message:{resultType.Message}. Please try it again.";
                throw new Exception(userErrorMsg);
            }

            if (resultType.Ack == AckCodeType.Warning)
            {
                //Todo:Notifications
            }


            return resultType;
        }

        public static Dictionary<string, string> BuildTokenApiHeader()
        {
            var headers = new Dictionary<string, string>();
            var cred = GlobalVar.EbayAppId + ":" + GlobalVar.EbayCertId;
            headers.Add("Authorization", "Basic " + Encrypt.ToBase64String(cred));
            return headers;
        }


    }
}