using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;

namespace WebAppPayBill.Services.DocumentServices
{
    public class DocumentService : IDocumentService
    {
        private static string _baseUrl;
        public DocumentService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<DocumentModel>> GetDocuments(int? Id)
        {
            List<DocumentModel> lista = new List<DocumentModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/Documents/GetDocuments");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<DocumentModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/Bill/GetBills?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<DocumentModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }
        public async Task<bool> AddDocument(DocumentModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Document/CreateDocument", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpDocument(DocumentModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Document/UpdateDocument", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
