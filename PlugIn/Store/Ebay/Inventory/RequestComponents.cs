using System.Collections.Generic;

namespace Auu.PlugIn.Store.EbayApi.Inventory
{
    public static class RequestComponents
    {
        public static Dictionary<string, string> BuildCommonHeader(string token)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer "+token);
            return headers;
        }
    }
    
    
}