using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;

namespace Wrox.BooksRead.Web.Models
{
    public class RedisLib
    {

        private static IDatabase cache;
        public static void SetCache<T> (String key, T obj)
        {
            if (cache == null) 
              {
              cache = RedisCacheExtension.Connection.GetDatabase();
              }
            cache.StringSet(key, RedisCacheExtension.Serialize<T>(obj));
        }

        public static T GetCache<T>(String key, Func<T> missedFetchObj)
        {
            if (cache == null)
            {
                cache = RedisCacheExtension.Connection.GetDatabase();
            }

            byte[] cachedItem = cache.StringGet(key);
            T obj = RedisCacheExtension.Deserialize<T>(cachedItem);
            if (obj == null)
            {
                obj = missedFetchObj();
                SetCache<T>(key, obj);
            }
            return obj;
        }


    }
    internal class RedisCacheExtension
    {

        internal  static T Deserialize<T>(Byte[] bytes)
        {
            if (bytes == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                T result = (T)bf.Deserialize(ms);
                return result;
            }
        }

        internal static Byte[] Serialize<T>(T obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
        return ConnectionMultiplexer.Connect
        //("mattcoder.redis.cache.windows.net:6380,password = 8JF9OopCirmC1IwBjYQp1BM2uLIRh5PYHcMNDimUxBU =,ssl = True,abortConnect = False");
            ("mattcoder.redis.cache.windows.net:6380,password = a58Wff8eKwr8ULFIp5XwCd2o8cF8DnJVM1BUZtZrEnk=,ssl=True,abortConnect=False");
            // ("mattcoder.redis.cache.windows.net:6380,password = sMmasAJKAsyyFfjNKpNCP1f9oC0eyM02Ik3 + C / yCSOk =,ssl = True,abortConnect = False");


        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}