using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace YinZiAttack
{
    public class StHttp
    {
        public delegate void ResultEventHandle(HttpResult httpResult);
        public event ResultEventHandle ResultEvent;
        public HttpClient HttpClient { get; set; } = new HttpClient();
        public string BaseUrl { get; private set; }
        public StHttp(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }
        public string Get(string api)
        {
            return null;
        }
        public string Post(string api, HttpContent httpContent)
        {
            string url = $"{this.BaseUrl}{api}";
            string result = this.HttpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            HttpResult httpResult = new HttpResult();
            httpResult.Result = result;
            httpResult.IsSuccessed = true;
            this.ResultEvent?.BeginInvoke(httpResult, null, null);
            return result;
        }
    }
}
