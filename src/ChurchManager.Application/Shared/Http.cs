//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ChurchManager.Application.Shared
//{
//    public static class Http
//    {
//        public static async Task<TResponse> Get<TResponse>(string url, CancellationToken cancellationToken = default, int timeOut = 0) where TResponse : class 
//        {
//            using var httpClient = new HttpClient();
//            try
//            {
//                if (timeOut > 0)
//                    httpClient.Timeout = TimeSpan.FromSeconds(timeOut);

//                using var response = await httpClient.GetAsync(url, cancellationToken);
                
//                if (!response.IsSuccessStatusCode)
//                    return null;

//                var content = await response.Content.ReadAsStringAsync(cancellationToken);
//                return JsonConvert.DeserializeObject<TResponse>(content);
//            }
//            catch (Exception)
//            {
//                return null;
//            }
//        }
//    }
//}
