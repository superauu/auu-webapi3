//using System;
//using Auu.Models.System;
//using Auu.WebApi.Controllers.Base;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace Auu.WebApi.Controllers.System
//{
//    /// <summary>
//    ///     用户登录接口
//    /// </summary>
//    public class CustomerLoginController : BaseController
//    {
//        /// <summary>
//        ///     客户登录接口
//        /// </summary>
//        /// <param name="loginInfo"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [Route("login")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult Login([FromBody] LoginInfo loginInfo)
//        {
//            var user = CustomerService.GetSysCustomerInfo(SysDbHelper, loginInfo);
//            if (user != null)
//            {
//                var lr = CustomerService.GetLoginResult(Session, loginInfo, user);
//                return Ok(lr);
//            }
//
//            var er = new ErrorResult {error = new Error {name = "InvalidCredentialsError"}};
//            return Ok(er);
//        }
//
//
//        [HttpPost]
//        [Route("register")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult Register([FromBody] SysCustomerInfo user)
//        {
//            try
//            {
//                user.CreateDate = DateTime.Now;
//                var trialDaysStr = DictionaryService.GetDict("TrialDays");
//                user.ExpireDate = double.TryParse(trialDaysStr,out var trialDays) ? DateTime.Now.AddDays(trialDays) : DateTime.Now.AddDays(7);
//                user.UserName = user.UserName.ToLower().Trim();
//                user.Email = user.Email.ToLower().Trim();
//                SysDbHelper.Insert(user);
//                return Ok();
//            }
//            catch
//            {
//                var er = new Error2();
//                er.error = "Username or Email has been taken!";
//                return Ok(er);
//                //return StatusCode(601, "Username or Email has been taken!");
//            }
//        }
//    }
//}