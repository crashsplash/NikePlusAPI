using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NikePlusAPI
{
    public class APIClient
    {
        public APIClient(string valid_token = "")
        {
            token = valid_token;
        }

        private string token;
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        
        private HttpClient aClient = new HttpClient();
        public HttpClient Client
        {
            get
            {
                aClient.DefaultRequestHeaders.Clear();
                if (!string.IsNullOrEmpty(token))
                {                    
                    aClient.DefaultRequestHeaders.Add("access_token", token);
                }
                return aClient;
            }
        }
    }
}
