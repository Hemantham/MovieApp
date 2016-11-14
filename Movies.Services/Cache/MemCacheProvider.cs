using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.API.API.Cache;

namespace Movies.Services.Cache
{
    public class MemCachProvider : CachingBase, ICacheProvider
    {
        private static MemCachProvider _memCachProvider;

        public MemCachProvider()
        {
        }

        public override void AddItem<T>(string key, T value)
        {
            base.AddItem(key, value);
        }

        public virtual T GetItem<T>(string key)
        {
            return base.GetItem<T>(key,false);
            //Remove default is true because it's Global Cache!
        }

        public override T GetItem<T>(string key, bool remove)
        {
            return base.GetItem<T>(key, remove);
        }

        public T GetItemAndAdd<T>(string key, Func<T> getFromRepo)
        {
            var cache = GetItem<T>(key);

            if (cache == null)
            {
                cache = getFromRepo();
                AddItem(key, cache);
            }
           
              return cache;
            
        }

        public void Clear()
        {
            List<string> cacheKeys = Cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                Cache.Remove(cacheKey);
            }
        }

        public static MemCachProvider Instance
        {
            get
            {
                if (_memCachProvider == null)
                {
                    _memCachProvider = new MemCachProvider();
                }
                return _memCachProvider;
            }
        }
    }
}
