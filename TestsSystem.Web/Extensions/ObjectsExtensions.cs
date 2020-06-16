using System;
using System.Collections.Generic;
using System.Net.Http;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Models;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Extensions
{
    public static class ObjectsExtensions
    {
        public static HttpClient With(this HttpClient client, Dictionary<string, string> headers)
        {
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            return client;
        }

        public static bool ToBoolenExpire(this SessionUser user)
        {
            if (user == null) return true;
            else return user.Expiration < DateTimeOffset
                    .UtcNow.ToUnixTimeMilliseconds();
        }

        public static List<ViewSubject> ToSubjectView(this List<DtoSubject> subjects)
        {
            var list = new List<ViewSubject>();
            if (subjects != null && subjects.Count > 0)
            {
                for (int i = 0; i < subjects.Count; i++)
                {
                    list.Add(new ViewSubject
                    {
                        SubjectId = subjects[i].Id,
                        SubjectName = subjects[i].Name,
                        Expanded = i == 0
                    });
                }
            }
            return list;
        }
    }
}
