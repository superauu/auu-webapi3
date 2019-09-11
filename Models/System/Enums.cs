namespace Auu.Models.System
{
    public enum SysUserStatus
    {
        Available,
        Unavailable
    }

    public enum ServiceStatus
    {
        //0正常，1过期，2停服，3释放,4创建数据库中,5创建数据库失败
        Active,
        Expired,
        Stopped,
        Released,
        CreatingDb,
        CreateDbFailed
    }
}