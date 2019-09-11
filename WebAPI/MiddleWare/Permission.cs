//using System.Collections.Generic;
//using System.Linq;
//using Autofac;
//using Auu.Framework.Common;
//using Auu.Framework.Common.Session;
//using Auu.Framework.DbControllers.Base;
//using Auu.Models.SystemModel.SystemSetup;
//
//namespace Auu.WebAPI.MiddleWare
//{
//    /// <summary>
//    ///     用户权限实体
//    /// </summary>
//    public class Permission
//    {
//        /// <summary>
//        ///     权限类型枚举
//        /// </summary>
//        public enum PermissionType
//        {
//            /// <summary>
//            ///     添加权限
//            /// </summary>
//            Add,
//
//            /// <summary>
//            ///     删除权限
//            /// </summary>
//            Delete,
//
//            /// <summary>
//            ///     查询权限
//            /// </summary>
//            Inquire,
//
//            /// <summary>
//            ///     编辑权限
//            /// </summary>
//            Update,
//
//            /// <summary>
//            ///     导出权限
//            /// </summary>
//            Export,
//
//            /// <summary>
//            ///     导入权限
//            /// </summary>
//            Import,
//
//            /// <summary>
//            ///     其它权限
//            /// </summary>
//            Other
//        }
//
//        private readonly string _sessionId;
//
//        /// <summary>
//        ///     初始化用户权限信息
//        /// </summary>
//        /// <param name="sessionId"></param>
//        public Permission(string sessionId)
//        {
//            _sessionId = sessionId;
//
//            var perm = RedisSession.Get(_sessionId, "__permission__");
//            if (!string.IsNullOrEmpty(perm))
//            {
//                UserModules = Json.GetObject<T_User_Module[]>(perm);
//            }
//            else
//            {
//                UserModules = GetPermission();
//                var json = Json.GetJson(UserModules);
//                RedisSession.Set(sessionId, "__permission__", json);
//            }
//        }
//
//        /// <summary>
//        ///     用户所有权限列表
//        /// </summary>
//        /// <returns></returns>
//        public T_User_Module[] UserModules { get; set; }
//
//        private T_User_Module[] GetPermission()
//        {
//            var userInfo = Json.GetObject<SessionUserInfo>(Redis.Get(_sessionId));
//            if (userInfo == null)
//                return null;
//            var accountName = userInfo.UserId;
//            using (var scope = LocContainer.Main.BeginLifetimeScope())
//            {
//                var db = scope.Resolve<IDbHelper>();
//                var roles = db.QueryDynamicList($"select roleid from t_account_role where accountname='{accountName}'");
//                //List<string> rolesId=new List<string>();
//                var rolesId = "";
//                foreach (var role in roles)
//                    //rolesId.Add(role.roleid as string);
//                    rolesId += "" + role.roleid + ",";
//                rolesId += "-1";
//                var ums = db.QueryList<T_User_Module>($"select * from t_user_module where accountname='{accountName}'");
//                var result = new List<T_User_Module>();
//                //处理用户账号权限
//                if (ums.Count > 0)
//                    foreach (var um in ums)
//                        if (result.Any(e => e.ModuleId == um.ModuleId))
//                        {
//                            var t = result.First(e => e.ModuleId == um.ModuleId);
//                            result.Remove(t);
//                            if (t.IsAdd == -1 || um.IsAdd == -1)
//                                t.IsAdd = -1;
//                            else
//                                t.IsAdd = t.IsAdd > um.IsAdd ? t.IsAdd : um.IsAdd;
//                            if (t.IsDelete == -1 || um.IsDelete == -1)
//                                t.IsDelete = -1;
//                            else
//                                t.IsDelete = t.IsDelete > um.IsDelete ? t.IsDelete : um.IsDelete;
//                            if (t.IsExport == -1 || um.IsExport == -1)
//                                t.IsExport = -1;
//                            else
//                                t.IsExport = t.IsExport > um.IsExport ? t.IsExport : um.IsExport;
//                            if (t.IsImport == -1 || um.IsImport == -1)
//                                t.IsImport = -1;
//                            else
//                                t.IsImport = t.IsImport > um.IsImport ? t.IsImport : um.IsImport;
//                            if (t.IsInquire == -1 || um.IsInquire == -1)
//                                t.IsInquire = -1;
//                            else
//                                t.IsInquire = t.IsInquire > um.IsInquire ? t.IsInquire : um.IsInquire;
//                            if (t.IsOther == -1 || um.IsOther == -1)
//                                t.IsOther = -1;
//                            else
//                                t.IsOther = t.IsOther > um.IsOther ? t.IsOther : um.IsOther;
//                            if (t.IsUpdate == -1 || um.IsUpdate == -1)
//                                t.IsUpdate = -1;
//                            else
//                                t.IsUpdate = t.IsUpdate > um.IsUpdate ? t.IsUpdate : um.IsUpdate;
//
//                            result.Add(t);
//                        }
//                        else
//                        {
//                            result.Add(um);
//                        }
//
//                //处理用户角色权限
//                var str = "select * from t_role_module where roleid in (" + rolesId + ")";
//                var rms = db.QueryList<T_Role_Module>(str);
//                if (rms.Count > 0)
//                    foreach (var rm in rms)
//                    {
//                        var um = new T_User_Module();
//                        um.AccountName = accountName;
//                        um.ModuleId = rm.ModuleId;
//                        um.IsAdd = rm.IsAdd;
//                        um.IsDelete = rm.IsDelete;
//                        um.IsExport = rm.IsExport;
//                        um.IsImport = rm.IsImport;
//                        um.IsInquire = rm.IsInquire;
//                        um.IsOther = rm.IsOther;
//                        um.IsUpdate = rm.IsUpdate;
//                        if (result.Any(e => e.ModuleId == um.ModuleId))
//                        {
//                            var t = result.First(e => e.ModuleId == um.ModuleId);
//                            result.Remove(t);
//                            if (t.IsAdd == -1 || um.IsAdd == -1)
//                                t.IsAdd = -1;
//                            else
//                                t.IsAdd = t.IsAdd > um.IsAdd ? t.IsAdd : um.IsAdd;
//                            if (t.IsDelete == -1 || um.IsDelete == -1)
//                                t.IsDelete = -1;
//                            else
//                                t.IsDelete = t.IsDelete > um.IsDelete ? t.IsDelete : um.IsDelete;
//                            if (t.IsExport == -1 || um.IsExport == -1)
//                                t.IsExport = -1;
//                            else
//                                t.IsExport = t.IsExport > um.IsExport ? t.IsExport : um.IsExport;
//                            if (t.IsImport == -1 || um.IsImport == -1)
//                                t.IsImport = -1;
//                            else
//                                t.IsImport = t.IsImport > um.IsImport ? t.IsImport : um.IsImport;
//                            if (t.IsInquire == -1 || um.IsInquire == -1)
//                                t.IsInquire = -1;
//                            else
//                                t.IsInquire = t.IsInquire > um.IsInquire ? t.IsInquire : um.IsInquire;
//                            if (t.IsOther == -1 || um.IsOther == -1)
//                                t.IsOther = -1;
//                            else
//                                t.IsOther = t.IsOther > um.IsOther ? t.IsOther : um.IsOther;
//                            if (t.IsUpdate == -1 || um.IsUpdate == -1)
//                                t.IsUpdate = -1;
//                            else
//                                t.IsUpdate = t.IsUpdate > um.IsUpdate ? t.IsUpdate : um.IsUpdate;
//
//                            result.Add(t);
//                        }
//                        else
//                        {
//                            result.Add(um);
//                        }
//                    }
//
//                return result.ToArray();
//            }
//        }
//
//        /// <summary>
//        ///     检查当前session是否对参数url有访问权限
//        /// </summary>
//        /// <param name="url"></param>
//        /// <returns></returns>
//        public bool CheckUserPermission(string url)
//        {
//            if (!url.StartsWith("/api/"))
//                return false;
//            url = url.Substring(5); //去掉前面的api字符
//            var words = url.Split("/");
//            if (words.Length < 2)
//                return false;
//            var moduleName = words[0];
//            PermissionType pt;
//            switch (words[1])
//            {
//                case "add":
//                    pt = PermissionType.Add;
//                    break;
//
//                case "edit":
//                    pt = PermissionType.Update;
//                    break;
//
//                case "delete":
//                    pt = PermissionType.Delete;
//                    break;
//
//                case "getlist":
//                    pt = PermissionType.Inquire;
//                    break;
//
//                case "get":
//                    pt = PermissionType.Inquire;
//                    break;
//
//                case "export":
//                    pt = PermissionType.Export;
//                    break;
//
//                case "import":
//                    pt = PermissionType.Import;
//                    break;
//
//                default:
//                    pt = PermissionType.Other;
//                    break;
//            }
//
//            return CheckUserPermission(moduleName, pt);
//        }
//
//        /// <summary>
//        ///     检查当前用户权限
//        /// </summary>
//        /// <param name="moduleName">模块汉字名</param>
//        /// <param name="pt">权限类别</param>
//        /// <returns></returns>
//        private bool CheckUserPermission(string moduleName, PermissionType pt)
//        {
//            //TODO: 这里可以考虑用redis
//            using (var scope = LocContainer.Main.BeginLifetimeScope())
//            {
//                var db = scope.Resolve<IDbHelper>();
//                var moduleOid = db.QueryOne<dynamic>("select oid from t_module where name='" + moduleName + "'");
//                var oid = moduleOid.oid;
//                int count;
//                switch (pt)
//                {
//                    case PermissionType.Add:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsAdd == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Delete:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsDelete == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Export:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsExport == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Import:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsImport == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Inquire:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsInquire == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Other:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsOther == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    case PermissionType.Update:
//                        count = UserModules.Count(m => m.ModuleId == oid && m.IsUpdate == 1);
//                        if (count > 0)
//                            return true;
//                        else
//                            return false;
//
//                    default:
//                        return false;
//                }
//            }
//        }
//    }
//}