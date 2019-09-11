//using Autofac;
//using Auu.Framework.Common;
//using Auu.Framework.DbControllers.Base;
//using Auu.Models.System;
//
//namespace Auu.Service
//{
//    public class CustomerService
//    {
//        public static SysCustomerInfo GetSysCustomerInfo(IDbHelper db,LoginInfo loginInfo)
//        {
//            var strSql =
//                $"select * from SysCustomerInfo where (UserName='{loginInfo.Username.ToLower().Trim()}' or Email='{loginInfo.Username.ToLower().Trim()}') and Password='{loginInfo.Password}'";
//            var user = db.QueryOne<SysCustomerInfo>(strSql);
//            return user;
//        }
//        
//        public static LoginResult GetLoginResult(ISessionBase session,LoginInfo loginInfo, SysCustomerInfo user)
//        {
//            var lr = new LoginResult();
//            user.Password = "";
//            lr.user = user;
//            using (var scope = LocContainer.Main.BeginLifetimeScope())
//            {
//                var sessionUser = scope.Resolve<ISessionUser>();
//                sessionUser.UserId = user.UserName;
//                sessionUser.ClientType = loginInfo.ClientType;
//                sessionUser.ConnString = user.ConnString;
//                lr.token = session.Register(sessionUser);
//            }
//
//            lr.redirect = loginInfo.Redirect;
//            return lr;
//        }
//    }
//}