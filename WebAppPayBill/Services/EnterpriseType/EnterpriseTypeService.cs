using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services.EnterpriseType
{
    public class EnterpriseTypeService : IEnterpriseTypeService
    {
        private static string _baseUrl;
        public EnterpriseTypeService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<EnterpriseTypeModel>> GetEnterpriseTypes(int? Id)
        {
            List<EnterpriseTypeModel> lista = new List<EnterpriseTypeModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/EnterpriseType/GetEnterpriseTypes");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<EnterpriseTypeModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/EnterpriseType/GetEnterpriseTypes?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<EnterpriseTypeModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }

        public async Task<EnterpriseTypeModel> GetEnterpriseType(int Id)
        {
            var lista = new EnterpriseTypeModel();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/v1/EnterpriseType/GetEnterpriseTypes?etyId=" + Id);

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<EnterpriseTypeModel>>(json_respuesta);
                lista = new EnterpriseTypeModel
                {
                    etyId = resultado.FirstOrDefault().etyId,
                    etyName = resultado.FirstOrDefault().etyName

                };
            }

            return lista;
        }
        public async Task<bool> AddEnterpriseType(EnterpriseTypeModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/EnterpriseType/CreateEnterpriseType", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpEnterpriseType(EnterpriseTypeModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/EnterpriseType/UpdateEnterpriseType", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
