using System;
using System.Collections.Generic;

namespace WArcherButchers.ServerApp.PaymentSense
{
    public static class DictionaryExistions
    {
        public static void AddIfExists(this Dictionary<string, object> to, Dictionary<string, object> from, string key)
        {
            if (from.TryGetValue(key, out object value)) to.Add(key, value);
        }

        public static void Add(this Dictionary<string, object> to, Dictionary<string, object> from, string key)
        {
            if (from.TryGetValue(key, out object value))
            {
                to.Add(key, value);
            }
            else
            {
                throw new ArgumentException($"{key} should exist in dictionary");
            }
        }
    }
}