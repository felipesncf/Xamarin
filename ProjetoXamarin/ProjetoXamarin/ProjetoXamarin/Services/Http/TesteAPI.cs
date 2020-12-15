using Newtonsoft.Json;
using ProjetoXamarin.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoXamarin.Services.Http
{
    class TesteAPI
    {
        public async Task<Cambio> GetCambios()
        {
            try
            {
                string url = "https://openexchangerates.org/api/latest.json?app_id=67c72373c92046aba3a13f6b57f9b653";
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var output = JsonConvert.DeserializeObject<ExchangeRate>(response);

                var divisesGrid = new Cambio();

                foreach (var item in output.Rates)
                {
                    divisesGrid.Cambios.Add(new Cambio { Sigla = item.Key, Valor = item.Value });
                }
                return divisesGrid;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
