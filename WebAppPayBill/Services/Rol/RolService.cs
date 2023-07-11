using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services.Rol
{
    public class RolService : IRolService
    {
        private static string _baseUrl;
        public RolService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<RolModel>> GetRoles(int? Id)
        {
            List<BillModel> lista = new List<BillModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/Bill/GetBills");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<BillModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/Bill/GetBills?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<BillModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }
        public async Task<bool> AddRol(RolModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Bill/CreateBill", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpRol(RolModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Bill/UpdateBill", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
