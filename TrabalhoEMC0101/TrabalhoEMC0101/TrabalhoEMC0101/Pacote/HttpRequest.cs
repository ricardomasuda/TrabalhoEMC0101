using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static TrabalhoEMC0101.Pacote.Request;

namespace TrabalhoEMC0101.Pacote
{
    class HttpRequest<Request>
    {
        const string URL = "https://api.thingspeak.com/channels/1259078/feeds.json?api_key=GPMP5WBQX96M5LTK&results=1";

        public class ApiResponse
        {
            public Object feeds { get; set; }
            public Object channel { get; set; }
        }

        public static async Task<ApiResponse> GetAsync()
        {
         
            ApiResponse _returnGet;
          
            try
            {
                //var _json = JsonConvert.SerializeObject(_requisicao);
                var _url = URL ;

                HttpClient _client = new HttpClient();
                _client.Timeout = new TimeSpan(0, 0, 15);

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applcation/json"));
              

                HttpResponseMessage _result = null;
               
                    // var _content = new StringContent(_json, Encoding.UTF8, "application/json");
                    Debug.WriteLine("--------INICIO-----------");
                    Debug.WriteLine(_url);
                    _result = await _client.GetAsync(_url);
                

                //var _content = new StringContent(_json, Encoding.UTF8, "application/json");
                //var _result = await _client.PostAsync(_url, _content);

                var _jsonResposta = _result.Content.ReadAsStringAsync().Result;

                Debug.WriteLine("--------fim-----------");
                Debug.WriteLine(_jsonResposta);
                // _returnGet = _jsonResposta;


                _returnGet = JsonConvert.DeserializeObject<ApiResponse>(_jsonResposta);
            }
            catch (Exception e)
            {
                _returnGet = null;
            }
            return _returnGet;
        }
    }
}
