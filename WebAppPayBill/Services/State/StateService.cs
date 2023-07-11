using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services.State
{
    public class StateService : IStateService
    {
        private static string _baseUrl;
        public StateService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<StateModel>> GetStates(int? Id)
        {
            List<StateModel> lista = new List<StateModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/State/GetStates");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<StateModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/State/GetStates?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<StateModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }
        public async Task<bool> AddState(StateModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/State/CreateState", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpState(StateModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/State/UpdateState", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
