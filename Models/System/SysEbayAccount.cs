using System;
using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    //Ebay帐号表
    public class SysEbayAccount:IEntity
    {
        public string Id { get; set; } //自增长编号
        public string EbayId { get; set; } //ebay的唯一标识
        public string RefreshToken { get; set; } //oauth用的刷新token，这个有效期应该是1年半。
        public DateTime RefreshTokenExpireTime { get; set; } //刷新token的过期时间
        public string UserName { get; set; } //所属的用户名
        public string Email { get; set; }
        public string Site { get; set; }
        public string StoreUrl { get; set; }
        public string Status { get; set; }
    }
}