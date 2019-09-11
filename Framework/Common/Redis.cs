using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Auu.Framework.Common
{
    public static class Redis
    {
        /// <summary>
        ///     全局只使用这一个变量来连接redis
        /// </summary>
        private static ConnectionMultiplexer _redis;

        public static void InitRedis(string server, string pwd)
        {
            var serverName = server;
            var password = pwd;
            _redis = ConnectionMultiplexer.Connect(serverName + ",password=" + password + ",DefaultDatabase=0");
        }

        /// <summary>
        ///     将键值对保存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>成功true，失败false</returns>
        public static bool Set(string key, string value)
        {
            var db = _redis.GetDatabase();
            return db.StringSet(key, value);
        }

        /// <summary>
        ///     获取redis中某键的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string Get(string key)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(key);
        }

        /// <summary>
        ///     判断键是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>存在true，不存在false</returns>
        public static bool Exist(string key)
        {
            var db = _redis.GetDatabase();
            return db.KeyExists(key);
        }

        /// <summary>
        ///     将键值对保存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>成功true，失败false</returns>
        public static bool SetInt(string key, int value)
        {
            var db = _redis.GetDatabase();
            return db.StringSet(key, value);
        }

        /// <summary>
        ///     删除指定的键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool Del(string key)
        {
            var db = _redis.GetDatabase();
            return db.KeyDelete(key);
        }

        /// <summary>
        ///     删除指定的键
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public static long Del(string[] redisKey)
        {
            var keys = new List<RedisKey>();
            foreach (var hkey in redisKey) keys.Add(hkey);
            var db = _redis.GetDatabase();
            return db.KeyDelete(keys.ToArray());
        }

        /// <summary>
        ///     如果有多条键值对要插入，直接使用这个方法，不要使用循环
        /// </summary>
        /// <param name="dic"></param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool MultiSet(Dictionary<string, string> dic)
        {
            var par = new List<KeyValuePair<RedisKey, RedisValue>>();
            foreach (var item in dic) par.Add(new KeyValuePair<RedisKey, RedisValue>(item.Key, item.Value));
            var db = _redis.GetDatabase();
            return db.StringSet(par.ToArray());
        }

        /// <summary>
        ///     一次性返回多个键的值
        /// </summary>
        /// <param name="keys">键组</param>
        /// <returns>值组</returns>
        public static RedisValue[] MultiGet(RedisKey[] keys)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(keys);
        }

        /// <summary>
        ///     返回redis中哈希表值的某一个键的值
        /// </summary>
        /// <param name="key">哈希表的键</param>
        /// <param name="hashKey">表内的键</param>
        /// <returns>值</returns>
        public static string HashGet(string key, string hashKey)
        {
            var db = _redis.GetDatabase();
            return db.HashGet(key, hashKey);
        }

        /// <summary>
        ///     返回redis中哈希表值的多个键的值
        /// </summary>
        /// <param name="key">哈希表的键</param>
        /// <param name="hashKey">表内的键</param>
        /// <returns>值</returns>
        public static RedisValue[] HashMGet(string key, string[] hashKey)
        {
            var db = _redis.GetDatabase();
            var keys = new List<RedisValue>();
            foreach (var hkey in hashKey) keys.Add(hkey);
            return db.HashGet(key, keys.ToArray());
        }

        /// <summary>
        ///     设置哈希表中的键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashKey"></param>
        /// <param name="hashValue"></param>
        /// <returns></returns>
        public static bool HashSet(string key, string hashKey, string hashValue)
        {
            var db = _redis.GetDatabase();
            return db.HashSet(key, hashKey, hashValue);
        }

        /// <summary>
        ///     一次性插入一个哈希表的键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="he"></param>
        public static void HashMultSet(string key, HashEntry[] he)
        {
            var db = _redis.GetDatabase();
            db.HashSet(key, he);
        }

        /// <summary>
        ///     一次性插入多个哈希表的键值对
        /// </summary>
        /// <param name="dics"></param>
        public static void HashMultSets(Dictionary<string, Dictionary<string, string>> dics)
        {
            var db = _redis.GetDatabase();
            var tasks = new List<Task>();
            var batch = db.CreateBatch();
            foreach (var item in dics)
            {
                var hashkey = item.Key;
                foreach (var child in item.Value) tasks.Add(batch.HashSetAsync(hashkey, child.Key, child.Value));
            }

            batch.Execute();
        }

        /// <summary>
        ///     一次性删除一个哈希表的多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hkeys"></param>
        public static void HashMultDel(string key, string[] hkeys)
        {
            var db = _redis.GetDatabase();
            var keys = new List<RedisValue>();
            foreach (var hkey in hkeys) keys.Add(hkey);
            db.HashDelete(key, keys.ToArray());
        }

        /// <summary>
        ///     获取某一个哈希表的全部键值对
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static HashEntry[] HashMultGet(string key)
        {
            var db = _redis.GetDatabase();
            return db.HashGetAll(key);
        }

        /// <summary>
        ///     获取某一个哈希表的全部键值对
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static RedisValue[] HkeysGet(string key)
        {
            var db = _redis.GetDatabase();
            return db.HashKeys(key);
        }

        /// <summary>
        ///     删除哈希表中指定的键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public static bool HashDel(string key, string hashKey)
        {
            var db = _redis.GetDatabase();
            return db.HashDelete(key, hashKey);
        }

        /// <summary>
        ///     判断哈希表中某个键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public static bool HashExists(string key, string hashKey)
        {
            var db = _redis.GetDatabase();
            return db.HashExists(key, hashKey);
        }

        /// <summary>
        ///     判断哈希表中键的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long HashLength(string key)
        {
            var db = _redis.GetDatabase();
            return db.HashLength(key);
        }

        /// <summary>
        ///     判断 是否存在并且查询出哈希表中某一个的值
        /// </summary>
        /// <param name="key">表</param>
        /// <param name="hskey">哈希表键</param>
        /// <returns></returns>
        public static dynamic[] GetDataListByHsRedis(string key, string hskey)
        {
            if (HashExists(key, hskey))
            {
                var val = HashGet(key, hskey);
                if (val != "")
                {
                    var ddd = Zip.GZipDecompressString(val);
                    var map2 = Json.GetObject<dynamic[]>(ddd);
                    return map2;
                }
            }

            return null;
        }

        /// <summary>
        ///     插入一个哈希表键 的数据
        /// </summary>
        /// <param name="key">表</param>
        /// <param name="hsKey">哈希表键</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static bool SetDataListByHsRedis(string key, string hsKey, object data)
        {
            var json = Json.GetJson(data);
            var ddd = Zip.GZipCompressString(json);
            return HashSet(key, hsKey, ddd);
        }
    }
}