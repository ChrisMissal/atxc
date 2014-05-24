using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Core
{
    using Entities;

    [DebuggerStepThrough]
    public static class Extensions
    {
        public static bool IsBetween(this int self, int low, int high)
        {
            return (low <= self && self <= high);
        }

        public static bool IsNullOrWhitespace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }

        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self) action(item);
        }

        public static void TryAdd<T>(this ICollection<T> self, Person person, T item) where T : IField
        {
            if (self.Contains(item))
                return;

            item.Person = person;
            item.Created = SystemClock.UtcNow;
            self.Add(item);
        }

        public static void TryAddRange<T>(this ICollection<T> self, IEnumerable<T> range, Person person) where T : IField
        {
            range.ForEach(obj => self.TryAdd(person, obj));
        }

        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

         public static string ToSlug(this string self)
         {
             if (string.IsNullOrWhiteSpace(self))
                return self;

             var s = self.ToLower();

             s = Regex.Replace(s, @"[^a-z0-9\s-]", "");                      // remove invalid characters
             s = Regex.Replace(s, @"\s+", " ").Trim();                       // single space
             s = s.Substring(0, s.Length <= 45 ? s.Length : 45).Trim();      // cut and trim
             return Regex.Replace(s, @"\s", "-");                               // insert hyphens
         }
    }
}