namespace Auu.Framework.Session
{
    public interface ISessionBase
    {
        bool CheckSession(string sessionId);
        /// <summary>
        ///     使用用户名获取session信息
        /// </summary>
        /// <returns></returns>
        string Register(ISessionUser sessionUser);
        /// <summary>
        ///     用sessionId登录，直接返回用户信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        ISessionUser GetUserBySessionId(string sessionId);

        /// <summary>
        ///     写自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string sessionId, string key, string value);

        /// <summary>
        ///     读自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string sessionId, string key);

        /// <summary>
        ///     删除自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        void Del(string sessionId, string key);
    }
}
