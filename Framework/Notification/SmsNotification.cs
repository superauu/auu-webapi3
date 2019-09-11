namespace Auu.Framework.Notification
{
    public class SmsNotification : INotification
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
            //                SendSMSCode (Phone, notification.Sender, notification.Title, notification.Message);
            //            }
            //            else
            //            {

            //            }
            //        }
            //    }
            //}
        }

        ///// <summary>
        ///// Receiver 电话号码 Message 验证码内容 Title 时间
        ///// </summary>
        ///// <param name="notification"></param>
        ///// <returns></returns>
        //public string Push2 (NotificationModule notification)
        //{
        //    string vvv = "";
        //    foreach (var user in notification.Receiver)
        //    {
        //        vvv = SendSMSCode1 (user, notification.Message, notification.Title);
        //    }
        //    return vvv;
        //}

        ///// <summary>
        ///// 发送短信验证码 会议
        ///// </summary>
        ///// <param name="phones"></param>
        ///// <param name="sms"></param>
        ///// <param name="min"></param>
        ///// <returns></returns>
        //public string SendSMSCode (string phones, string name, string title, string date)
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
        //    //传递数据的xml
        //    var stringxml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        //    stringxml += @"<TemplateSMS>
        //                    <to>" + phones + @"</to>
        //                    <appId>" + ss.appid + @"</appId>
        //                    <templateId>201460</templateId>//模板ID
        //                    <datas>
        //                        <data>" + name + @"</data>//模板{1}内容
        //                        <data>" + date + @"</data>//模板{2}内容
        //                        <data>" + title + @"</data>//模板{3}内容
        //                    </datas>
        //                    </TemplateSMS>";
        //    //xml转为链接需要的格式
        //    HttpContent httpContent = new StringContent (stringxml);
        //    var ddd = new MediaTypeHeaderValue ("application/xml");
        //    ddd.CharSet = "utf-8";
        //    httpContent.Headers.ContentType = ddd;
        //    //请求
        //    HttpResponseMessage response = httpClient.PostAsync ("https://" + ss.wrhost + ":8883/2013-12-26/Accounts/" + ss.accountsid + "/SMS/TemplateSMS?sig=" + sig, httpContent).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync ();
        //        var map2 = Json.GetObject<dynamic> (t.Result);
        //        if (map2 != null)
        //        {
        //            return map2.statusCode;
        //        }
        //    }
        //    return "";
        //}

        ///// <summary>
        ///// 发送短信验证码
        ///// </summary>
        ///// <param name="phones"></param>
        ///// <param name="sms"></param>
        ///// <param name="min"></param>
        ///// <returns></returns>
        //public string SendSMSCode1 (string phones, string sms, string min)
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
        //    //传递数据的xml
        //    var stringxml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        //    stringxml += @"<TemplateSMS>
        //                    <to>" + phones + @"</to>
        //                    <appId>" + ss.appid + @"</appId>
        //                    <templateId>201460</templateId>//模板ID
        //                    <datas>
        //                        <data>" + sms + @"</data>//模板{1}内容
        //                        <data>" + min + @"分钟</data>//模板{2}内容
        //                    </datas>
        //                    </TemplateSMS>";
        //    //xml转为链接需要的格式
        //    HttpContent httpContent = new StringContent (stringxml);
        //    var ddd = new MediaTypeHeaderValue ("application/xml");
        //    ddd.CharSet = "utf-8";
        //    httpContent.Headers.ContentType = ddd;
        //    //请求
        //    HttpResponseMessage response = httpClient.PostAsync ("https://" + ss.wrhost + ":8883/2013-12-26/Accounts/" + ss.accountsid + "/SMS/TemplateSMS?sig=" + sig, httpContent).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync ();
        //        var map2 = Json.GetObject<dynamic> (t.Result);
        //        if (map2 != null)
        //        {
        //            return map2.statusCode;
        //        }
        //    }
        //    return "";
        //}
    }
}