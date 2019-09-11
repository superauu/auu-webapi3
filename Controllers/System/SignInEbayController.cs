//using System;
//using System.Linq;
//using AcSeller8.Framework.Common;
//using Auu.Framework.Common;
//using Auu.Models.System;
//using Auu.PlugIn.Store.EbayApi;
//using Auu.PlugIn.Store.EbayApi.EbayModels.Request;
//using Auu.WebApi.Controllers.Base;
//using DapperExtensions;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace Auu.WebApi.Controllers.System
//{
//    public class SignInEbayController:BaseController
//    {
//        /// <summary>
//    ///     接收ebay的用户登录验证码
//    /// </summary>
//        [HttpGet]
//        [Route("SignInEbay")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult SignInEbayAndGetTokenRightNow(string code, int expiresIn)
//        {
//            var token = Token.GetNewUserToken(code);
//            var user = TradingApi.GetUser(token.access_token);
//            if (user?.User == null)
//            {
//                return Redirect("/sf/LinkFail.html");
//            }
//
//            SysEbayAccount mea = new SysEbayAccount
//            {
//                Id = Guid.NewGuid().ToString(),
//                Email = user.User.Email.ToLower().Trim(),
//                Site = user.User.Site.ToString(),
//                Status = user.User.Status.ToString(),
//                EbayId = user.User.UserID,
//                RefreshToken = token.refresh_token,
//                RefreshTokenExpireTime = DateTime.Now.AddSeconds(token.refresh_token_expires_in),
//                StoreUrl = user.User.SellerInfo.StoreURL
//            };
//            var emailKey = "LinkEmail" + mea.Email.ToLower().Trim();
//            if (Redis.Exist(emailKey))
//            {
//                mea.UserName = Redis.Get(emailKey);
//            }
//            else
//            {
//                return Redirect("/sf/LinkFail.html");
//            }
//            
//
//            //将token保存到redis
//            var tokenkey = "tokenemail-" + mea.Email.ToLower().Trim();
//            UsefulToken ut = new UsefulToken();
//            ut.token = token.access_token;
//            ut.expire = DateTime.Now.AddSeconds(token.expires_in);
//            Redis.Set(tokenkey, Framework.Common.Json.GetJson(ut));
//            
//            var predicate = Predicates.Field<SysEbayAccount>(f => f.Email, Operator.Eq, mea.Email);
//            var mEbayAccounts = SysDbHelper.GetList<SysEbayAccount>(predicate).ToList();
//            if (mEbayAccounts.Any())
//            {
//                var t1 = mEbayAccounts.First();
//                t1.Site = mea.Site;
//                t1.Status = mea.Status;
//                t1.EbayId = mea.EbayId;
//                t1.RefreshToken = mea.RefreshToken;
//                t1.RefreshTokenExpireTime = mea.RefreshTokenExpireTime;
//                t1.StoreUrl = mea.StoreUrl;
//                t1.UserName = mea.UserName;
//                SysDbHelper.Update(t1);
//            }
//            else
//            {
//                SysDbHelper.Insert(mea);
//            }
//
//            return Redirect("/sf/LinkSuccess.html");
//        }
//
//        [HttpPost]
//        [Route("linkEbaySaveEmail")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult LinkEbaySaveEmail([FromBody] EbayEmail ee)
//        {
//            try
//            {
//                ee.account = Session.GetUserBySessionId(SessionId).UserId;
//                var emailKey = "LinkEmail" + ee.ebayEmail.ToLower().Trim();
//                //看看是否有已经存在的该账号的信息
//                if (Redis.Exist("LinkAccount" + ee.account))
//                {
//                    var emailNeedDel = Redis.Get("LinkAccount" + ee.account);
//                    emailNeedDel = "LinkEmail" + emailNeedDel;
//                    if (Redis.Exist(emailNeedDel))
//                        Redis.Del(emailNeedDel);
//                }
//
//                Redis.Set(emailKey, ee.account);
//                Redis.Set("LinkAccount" + ee.account, ee.ebayEmail.ToLower().Trim());
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex);
//            }
//        }
//
//        [HttpGet]
//        [Route("GetEbayAccounts")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetEbayAccounts()
//        {
//            SysEbayAccount mea=new SysEbayAccount();
//            var predicate = Predicates.Field<SysEbayAccount>(f => f.UserName, Operator.Eq, Session.GetUserBySessionId(SessionId).UserId);
//            var t = SysDbHelper.GetList<SysEbayAccount>(predicate);
//            return Ok(t.ToList());
//        }
//        
//        [HttpDelete]
//        [Route("DeleteEbayAccounts/{userid}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult DeleteEbayAccounts(string userid)
//        {
//            SysDbHelper.Execute($"delete from SysEbayAccount where EbayId = '{userid}'");
//            return Ok();
//        }
//    }
//}