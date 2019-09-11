using System;
using System.Collections.Generic;
using Auu.Framework.Common;
using Auu.Models.System;
using Auu.PlugIn.Store.EbayApi.EbayModels.Request;
using Auu.PlugIn.Store.EbayApi.EbayModels.Response;

namespace Auu.PlugIn.Store.EbayApi
{
    public static class Token
    {
        private const string Url = "https://api.ebay.com/identity/v1/oauth2/token";

        public static string GetUserToken(SysEbayAccount user)
        {
            var json = Redis.Get("tokenemail-" + user.Email.ToLower().Trim());
            if (json != null)
            {
                var token = Json.GetObject<UsefulToken>(json);
                if (token.expire > DateTime.Now)
                    return token.token;
            }

            //用refresh重新获取token
            if (user.RefreshTokenExpireTime <= DateTime.Now)
                throw new Exception(user.Email + "'s Refresh Token is expired");

            var tokenResponse = RefreshUserToken(user.RefreshToken);
            var ut = new UsefulToken();
            ut.token = tokenResponse.access_token;
            ut.expire = DateTime.Now.AddSeconds(tokenResponse.expires_in);
            Redis.Set("tokenemail-" + user.Email.ToLower().Trim(), Json.GetJson(ut));
            return tokenResponse.access_token;
        }

        public static TokenResponse GetNewUserToken(string code)
        {
            var headers = EbayCommon.BuildTokenApiHeader();
            var kv = new Dictionary<string, string>();
            kv.Add("grant_type", "authorization_code");
            kv.Add("code", Encrypt.UrlDecode(code));
            kv.Add("redirect_uri", GlobalVar.EbayRuName);
            var result = Http.HttpPost(Url, headers, kv);
            var tokenResp = Json.GetObject<TokenResponse>(result);
            return tokenResp;
        }

        public static TokenResponse RefreshUserToken(string refreshToken)
        {
            var headers = EbayCommon.BuildTokenApiHeader();
            var kv = new Dictionary<string, string>();
            kv.Add("grant_type", "refresh_token");
            kv.Add("refresh_token", refreshToken);
            kv.Add("scope",
                "https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly");

            var result = Http.HttpPost(Url, headers, kv);
            var tokenResp = Json.GetObject<TokenResponse>(result);
            return tokenResp;
        }
    }
}