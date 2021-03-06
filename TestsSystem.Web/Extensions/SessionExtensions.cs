﻿using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using System;
using TestsSystem.Web.Models;

namespace TestsSystem.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObj<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObj<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
        public static bool HasExpired(this SessionUser user)
        {
            long nowUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (user != null && user.Expiration > nowUnix) return false;
            else return true;
        }
    }
}
