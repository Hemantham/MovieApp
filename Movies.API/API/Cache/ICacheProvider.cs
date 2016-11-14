using System;

namespace Movies.API.API.Cache
{
    public interface ICacheProvider
    {
        void AddItem<T>(string key, T value);
        T GetItem<T>(string key);
        T GetItemAndAdd<T>(string key, Func<T> getFromRepo);
        void Clear();
    }
}
