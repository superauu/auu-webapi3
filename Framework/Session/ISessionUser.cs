namespace Auu.Framework.Session
{
    public interface ISessionUser
    {
        string SessionId { get; set; }
        string UserId { get; set; }
        string ClientType { get; set; }
        string ConnString { get; set; }
    }
}
