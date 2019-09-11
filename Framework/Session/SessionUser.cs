namespace Auu.Framework.Session
{
    public class SessionUser:ISessionUser
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public string ClientType { get; set; }
        public string ConnString { get; set; }
    }
}
