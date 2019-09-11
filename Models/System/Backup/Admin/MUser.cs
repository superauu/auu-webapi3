using System;

namespace Auu.Models.System.Backup.Admin
{
    //用户信息、登录信息
    public class MUser
    {
        public int Id { get; set; } //自增长编号
        public string UserName { get; set; } //用户名
        public string Password { get; set; } //密码MD5加密
        public string DisplayName { get; set; } //显示名
        public string Email { get; set; } //email
        public string Tel { get; set; } //电话
        public int EbayAccountNumber { get; set; } //可以绑定的ebay帐号数量
        public DateTime ExpireDate { get; set; } //过期日期
        public DateTime CreateDate { get; set; } //帐号创建日期
        public int Status { get; set; } //帐号状态 0为可用，1为停用
        public string HeadImg { get; set; } //头像文件地址
    }
    
}