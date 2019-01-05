using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KC.Data
{
    public class CacheHandler<T> : CacheHandler where T : class
    {
        static object lockObj = new object();
        public static T Get(string key, Func<T> func, bool enableCaching = true)
        {
            if (!enableCaching) { return func(); }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("refresh=1"))
                HttpContext.Current.Cache[key] = null;
            var data = HttpContext.Current.Cache[key] as T;
            if (data == null)
            {
                lock (lockObj)
                {
                    data = HttpContext.Current.Cache[key] as T;
                    if (data == null)
                    {
                        data = func();
                        HttpContext.Current.Cache.Insert(key, data, null, DateTime.Now.AddMinutes(180), System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                }

            }
            return data;
        }
    }

    public class CacheHandler
    {
        public static void Clear(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public static void ClearContains(string key)
        {
            List<string> keys = new List<string>();
            IDictionaryEnumerator enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var cacheKey = enumerator.Key.ToString();
                if (cacheKey.Contains(key))
                    keys.Add(cacheKey);
            }
            keys.ForEach(cacheKey => HttpRuntime.Cache.Remove(cacheKey));
        }
    }
}
