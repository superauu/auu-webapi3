using System;
using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public class SysCustomerInfo:IEntity
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     企业名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        ///     手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        ///     账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     开通服务日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     服务过期日期
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        ///     企业数据库名称
        /// </summary>
        public string Database { get; set; }
        public string ConnString { get; set; }
        public float CurrentVersion{get;set;}


        /// <summary>
        ///     企业服务状态，正常、过期、停服等
        ///     0正常，1过期，2停服，3释放,4创建数据库中,5创建数据库失败
        /// </summary>
        public ServiceStatus Status { get; set; }

        /// <summary>
        ///     停止服务日期
        /// </summary>
        public DateTime StopServiceDate { get; set; }

        /// <summary>
        ///     rds实例编号
        /// </summary>
        public string RdsId { get; set; }

        /// <summary>
        ///     oss文件夹
        /// </summary>
        public string OssFolder { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        public int EbayAccountNumber { get; set; } //可以绑定的ebay帐号数量
    }
}