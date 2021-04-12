using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiCLient = new HttpClient();

        static GlobalVariables()
        {
            WebApiCLient.BaseAddress = new Uri("http://localhost:51610/api/");
            WebApiCLient.DefaultRequestHeaders.Accept.Clear();
            WebApiCLient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           
        }
    }
}