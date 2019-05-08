using Microsoft.Extensions.Caching.Memory;
using System;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Extentions
{
    public static class CacheExtentions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"{tokenId}-jwt";
    }
}
