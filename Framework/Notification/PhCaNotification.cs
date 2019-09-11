namespace Auu.Framework.Notification
{
    public class PhCaNotification : INotification
    {
        public void Push(NotificationModule notification)
        {
            //foreach (var user in notification.Receiver)
            //{
            //    var db = new DbHelper ();
            //    var post = db.QueryDynamicList ("select ifnull(Phone,'') as Phone from account_customer where UserAccount = '" + user + "'");
            //    if (post.Count > 0)
            //    {
            //        string Phone = post.ToArray () [0].Phone;
            //        if (Phone != null && Phone != "")
            //        {
            //            if (notification.Sender != "" && notification.Title != "" && notification.Message != "")
            //            {
            //                SendSMSVoice (Phone, notification.Sender, notification.Title, notification.Message, notification.Voicebo);
            //            }
            //            else
            //            {

            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public string Push2(NotificationModule notification)
        {
            return "";
        }

        ///// <summary>
        ///// 发送语音短信 会议
        ///// </summary>
        ///// <param name="phone"></param>
        ///// <param name="name"></param>
        ///// <param name="title"></param>
        ///// <param name="date"></param>
        ///// <param name="b"></param>
        ///// <returns></returns>
        //public string SendSMSVoice (string phone, string name, string title, string date, bool b)
        //{
        //    Sendsmss ss = new Sendsmss ();
        //    var shi = ss.GetRiQi (); //获取时间
        //    var sig = ss.GetZSig (shi); //获取sig
        //    var ato = ss.GetZAto (shi); //获取ato
        //    HttpClient httpClient = new HttpClient (); //http对象
        //    //表头参数
        //    httpClient.DefaultRequestHeaders.Accept.Clear ();
        //    httpClient.DefaultRequestHeaders.Accept.Add (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue ("application/json"));
        //    httpClient.DefaultRequestHeaders.TryAddWithoutValidation ("Authorization", Convert.ToBase64String (ato));
        //    var msg = "悦销提醒您:" + name + "邀请您参加" + date + "开始的,主题为" + title + "的会议,请您准时登录悦销参加!";
        //    //传递数据的xml
        //    var stringxml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        //    stringxml += @"<LandingCall>         
        //                    <appId>" + ss.appid + @"</appId>
        //                    <to>" + phone + @"</to>  
        //                    <mediaTxt>" + msg + @"</mediaTxt>
        //                    <playTimes>2</playTimes>
        //                    <displayNum></displayNum>
        //                    <userData>" + sig + @"</userData>
        //                    <respUrl>https://www.1zsale.com/v1/login/sellingcall</respUrl>
        //                    </LandingCall>";
        //    //xml转为链接需要的格式
        //    HttpContent httpContent = new StringContent (stringxml);
        //    var ddd = new MediaTypeHeaderValue ("application/xml");
        //    ddd.CharSet = "utf-8";
        //    httpContent.Headers.ContentType = ddd;
        //    //请求
        //    HttpResponseMessage response = httpClient.PostAsync ("https://" + ss.wrhost + ":8883/2013-12-26/Accounts/" + ss.accountsid + "/Calls/LandingCalls?sig=" + sig, httpContent).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync ();
        //        var map2 = Json.GetObject<dynamic> (t.Result);
        //        if (map2 != null)
        //        {
        //            if (map2.statusCode == "000000" && b)
        //            {
        //                Redis.SetDataListByHSRedis ("voice", sig, msg);
        //            }
        //            return map2.statusCode;
        //        }
        //    }
        //    return "";
        //}
    }
}