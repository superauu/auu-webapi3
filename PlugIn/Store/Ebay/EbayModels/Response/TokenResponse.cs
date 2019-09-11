namespace Auu.PlugIn.Store.EbayApi.EbayModels.Response
{
    public class TokenResponse
    {
        /// <summary>
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// </summary>
        public int refresh_token_expires_in { get; set; }

        /// <summary>
        /// </summary>
        public string token_type { get; set; }
    }
}