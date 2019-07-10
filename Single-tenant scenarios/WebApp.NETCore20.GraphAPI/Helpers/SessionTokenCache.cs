using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;

namespace WebApp.NETCore20.GraphAPI.Helpers
{
    // Store the user's access token in memory cache.
    public class SessionTokenCache
    {
        private static readonly object FileLock = new object();
        private readonly string cacheId;
        private readonly IMemoryCache memoryCache;
        private TokenCache cache = new TokenCache();

        public SessionTokenCache(string userId, IMemoryCache memoryCache)
        {
            // not object, we want the SUB
            cacheId = userId + "TokenCache";
            this.memoryCache = memoryCache;

            Load();
        }

        public TokenCache GetCacheInstance()
        {
            cache.SetBeforeAccess(BeforeAccessNotification);
            cache.SetAfterAccess(AfterAccessNotification);
            Load();

            return cache;
        }

        public void SaveUserStateValue(string state)
        {
            lock (FileLock)
            {
                memoryCache.Set(cacheId + "state", Encoding.ASCII.GetBytes(state));
            }
        }

        public string ReadUserStateValue()
        {
            string state;
            lock (FileLock)
            {
                state = Encoding.ASCII.GetString(memoryCache.Get(cacheId + "state") as byte[]);
            }

            return state;
        }

        public void Load()
        {
            lock (FileLock)
            {
                cache.Deserialize(memoryCache.Get(cacheId) as byte[]);
            }
        }

        public void Persist()
        {
            lock (FileLock)
            {
                // reflect changes in the persistent store
                memoryCache.Set(cacheId, cache.Serialize());
                // once the write operation took place, restore the HasStateChanged bit to false
                cache.HasStateChanged = false;
            }
        }

        // Empties the persistent store.
        public void Clear()
        {
            cache = null;
            lock (FileLock) {
                memoryCache.Remove(cacheId);
            }
        }

        // Triggered right before MSAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        private void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            Load();
        }

        // Triggered right after MSAL accessed the cache.
        private void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (cache.HasStateChanged)
            {
                Persist();
            }
        }
    }
}