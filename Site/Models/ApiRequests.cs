using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public static class ApiRequests
    {
        public static List<T> GenericGetRequest<T>(string a)
        {
            RestClient client = new RestClient(a);
            RestRequest request = new RestRequest();
            return JsonConvert.DeserializeObject<List<T>>(client.GetAsync(request).GetAwaiter().GetResult().Content);
        }
        public static Return GenericPostRequest<Return,Post>(Post postdto,string a)
        {
            RestClient client = new RestClient(a);
            RestRequest request = new RestRequest().AddBody(postdto);
            return JsonConvert.DeserializeObject<Return>(client.PostAsync(request).GetAwaiter().GetResult().Content);
        }
        public static void GenericDeleteRequest(string a)
        {
            RestClient client = new RestClient(a);
            RestRequest request = new RestRequest();
            client.DeleteAsync(request).GetAwaiter();
        }
    }
}
