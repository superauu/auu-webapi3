using System;

namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     查询客户列表结果类
    /// </summary>
    public class CustomerShortResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string Scode { get; set; }

        /// <summary>
        ///     状态描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     客户列表信息
        /// </summary>
        public Customer_Info_Short[] Customer { get; set; }
    }

    /// <summary>
    ///     客户详情结果类
    /// </summary>
    public class CustomerResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string Scode { get; set; }

        /// <summary>
        ///     状态描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     客户详情
        /// </summary>
        public Customer_Info Customer { get; set; }
    }

    /// <summary>
    ///     客户信息实体类
    /// </summary>
    public class Customer_Info
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public int Oid { get; set; }

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
        ///     qq
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        ///     微信
        /// </summary>
        public string Weixin { get; set; }

        /// <summary>
        ///     允许开通账号数量
        /// </summary>
        public int AccountNum { get; set; }

        /// <summary>
        ///     企业管理员账号
        /// </summary>
        public string AdminAccount { get; set; }

        /// <summary>
        ///     企业管理员密码
        /// </summary>
        public string AdminPassword { get; set; }

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

        /// <summary>
        ///     企业服务器地址
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        ///     企业服务状态，正常、过期、停服等
        ///     0正常，1过期，2停服，3释放,4创建数据库中,5创建数据库失败
        /// </summary>
        public int status { get; set; }

        /// <summary>
        ///     停止服务日期
        /// </summary>
        public DateTime StopServiceDate { get; set; }

        /// <summary>
        ///     容器应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        ///     容器服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        ///     容器集群编号
        /// </summary>
        public string JiqunId { get; set; }

        /// <summary>
        ///     负载均衡编号
        /// </summary>
        public string LSBId { get; set; }

        /// <summary>
        ///     rds编号
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

        /// <summary>
        ///     图标
        /// </summary>
        /// <returns></returns>
        public string Icon { get; set; }
    }

    /// <summary>
    ///     简要客户信息实体类
    /// </summary>
    public class Customer_Info_Short
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public int Oid { get; set; }

        /// <summary>
        ///     客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     创建服务日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     服务过期日期
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        ///     服务状态
        /// </summary>
        public int status { get; set; }

        /// <summary>
        ///     停止服务日期
        /// </summary>
        public DateTime StopServiceDate { get; set; }

        /// <summary>
        ///     联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        ///     手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        ///     图标
        /// </summary>
        /// <returns></returns>
        public string Icon { get; set; }
    }
}