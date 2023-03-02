using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMO.Common.HttpClients
{
    public class AdminHttpClient
    {

        public HttpClient Client { get; }

        public AdminHttpClient(HttpClient httpClient)
        {
            Client = httpClient;
            //Client.BaseAddress = new Uri("https://localhost:6001/api/");
        }

    }
}
