using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services
{
    public class BillService: IBillService
    {
        private static string _baseUrl;
        public BillService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<BillModel>> GetBills(int? Id)
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
            public async Task<BillModel> GetBill(int Id)
        {
            var lista = new BillModel();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.GetAsync("api/v1/Bill/GetBills?BillNumber=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<BillModel>>(json_respuesta);
                    lista = new BillModel
                    {
                        bilId = resultado.FirstOrDefault().bilId,
                        bilContract = resultado.FirstOrDefault().bilContract,
                        bilNumber = resultado.FirstOrDefault().bilNumber,
                        bilDescription = resultado.FirstOrDefault().bilName,
                        bilName = resultado.FirstOrDefault().bilName,
                        bilValuePay = resultado.FirstOrDefault().bilValuePay

                    };
                }

            return lista;
        }
        public async Task<bool> AddBill(BillModel obj)
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
        public async Task<bool> UpBill(BillModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/v1/Bill/UpdateBill", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


    }
}
