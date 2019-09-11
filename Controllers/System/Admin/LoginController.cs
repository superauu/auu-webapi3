//using System;
//using AcSeller8.Controllers.Base;
//using AcSeller8.Framework.Common;
//using AcSeller8.Models.SystemModel;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace AcSeller8.Controllers.SystemController
//{
//    /// <summary>
//    ///     用户登录接口
//    /// </summary>
//    public class LoginController : BaseController
//    {
//        /// <summary>
//        ///     用户登录接口
//        /// </summary>
//        /// <param name="loginInfo"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [Route("login")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult Login([FromBody] LoginInfo loginInfo)
//        {
//            loginInfo.Password = Encrypt.Md5(loginInfo.Password);
//            var strsql =
//                $"select * from MUser where (username='{loginInfo.Username.ToLower().Trim()}' or email='{loginInfo.Username.ToLower().Trim()}') and password='{loginInfo.Password}' and status=0";
//            var user = SysDbHelper.QueryOne<MUser>(strsql);
//            if (user != null)
//            {
//                var lr = new LoginResult();
//                user.Password = "";
//                lr.user = user;
//                //lr.token = Session.Register(user.UserName, "P");
//                lr.redirect = loginInfo.Redirect;
//                return Ok(lr);
//            }
//
//            var er = new ErrorResult();
//            er.error = new Error();
//            er.error.name = "InvalidCredentialsError";
//            return Ok(er);
//        }
//
//        [HttpPost]
//        [Route("register")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult Register([FromBody] MUser user)
//        {
//            try
//            {
//                user.CreateDate = DateTime.Now;
//                user.UserName = user.UserName.ToLower().Trim();
//                user.Email = user.Email.ToLower().Trim();
//                user.Password = Encrypt.Md5(user.Password);
//                //DbHelper.Insert(user);
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
//
//    /// <summary>
//    ///     用户登录信息
//    /// </summary>
//    public class LoginInfo
//    {
//        /// <summary>
//        ///     用户名
//        /// </summary>
//        /// <returns></returns>
//        public string Username { get; set; }
//
//        /// <summary>
//        ///     密码（md5加密）
//        /// </summary>
//        /// <returns></returns>
//        public string Password { get; set; }
//
//        public string Redirect { get; set; }
//    }
//
//    public class LoginResult
//    {
//        public MUser user { get; set; }
//        public string token { get; set; }
//        public string redirect { get; set; }
//    }
//}