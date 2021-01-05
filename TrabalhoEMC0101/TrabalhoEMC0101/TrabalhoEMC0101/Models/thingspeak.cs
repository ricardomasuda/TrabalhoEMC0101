using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrabalhoEMC0101.Pacote;
using static TrabalhoEMC0101.Pacote.Request;

namespace TrabalhoEMC0101.Models
{
    public class thingspeak
    {
        public async Task<feeds> BuscarInfo()
        {
            var response = await HttpRequest<SimppleRequest>.GetAsync();
            if (response != null)
            {
                try
                {
                    JArray jObject = response.feeds as JArray;
                    var ListaLocal = jObject.ToObject<List<feeds>>();
                    return ListaLocal[0];
                }
                catch (Exception e)
                {

                }
            }
            return null;
        }
    }
}
