using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DataEntryManager
{
    public static class WebClientExtension
    {
        public static void AddArray(this WebClient webClient, string key, params string[] values)
        {
            int index = webClient.QueryString.Count;

            foreach (string value in values)
            {
                webClient.QueryString.Add(key + "[" + index + "]", value);
                index++;
            }
        }

        public static void AddArray(this WebClient webClient, string key, List<string> values)
        {
            int index = webClient.QueryString.Count;

            foreach (string value in values)
            {
                webClient.QueryString.Add(key + "[" + index + "]", value);
                index++;
            }
        }
    }
}
