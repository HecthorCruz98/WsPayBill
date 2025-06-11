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
            List<RolModel> lista = new List<RolModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/Rol/GetRol");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<RolModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/Roles/GetRol?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<RolModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }

        public async Task<RolModel> GetRol(int Id)
        {
            var lista = new RolModel();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/v1/Rol/GetRol?rolId=" + Id);

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<RolModel>>(json_respuesta);
                lista = new RolModel
                {
                    rolId = resultado.FirstOrDefault().rolId,
                    rolName = resultado.FirstOrDefault().rolName


                };
            }

            return lista;
        }
        public async Task<bool> AddRol(RolModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Rol/CreateRol", content);

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

            var response = await cliente.PutAsync("api/v1/Rol/UpdateRol", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
