using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services.Enterprise
{
    public class EnterpriseService : IEnterpriseService
    {
        private static string _baseUrl;
        public EnterpriseService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<EnterpriseModel>> GetEnterprises(int? Id)
        {
            List<EnterpriseModel> lista = new List<EnterpriseModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/Enterprise/GetEnterprises");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<EnterpriseModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/Enterprise/GetEnterprises?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<EnterpriseModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }

          public async Task<EnterpriseModel> GetEnterprise(int Id)
        {
            var lista = new EnterpriseModel();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/v1/Enterprise/GetEnterprises?entId=" + Id);

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<EnterpriseModel>>(json_respuesta);
                lista = new EnterpriseModel
                {
                    entId = resultado.FirstOrDefault().entId,
                    entName = resultado.FirstOrDefault().entName,
                    etyId = resultado.FirstOrDefault().etyId


                };
 
            }
            return lista;
        }
        public async Task<bool> AddEnterprise(EnterpriseModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Enterprise/CreateEnterprise", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpEnterprise(EnterpriseModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/v1/Enterprise/UpdateEnterprise", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
