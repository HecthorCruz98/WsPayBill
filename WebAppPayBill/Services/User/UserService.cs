using Newtonsoft.Json;
using System.Text;
using WebAppPayBill.Models;


namespace WebAppPayBill.Services.User
{
    public class UserService : IUserService
    {
        private static string _baseUrl;
        public UserService()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<UserModel>> GetUsers(int? Id)
        {
            List<UserModel> lista = new List<UserModel>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            if (Id == 0)
            {
                var response = await cliente.GetAsync("api/v1/User/GetUsers");

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<UserModel>>(json_respuesta);
                    lista = resultado;
                }
            }
            else
            {
                var response = await cliente.GetAsync("api/v1/User/GetUsers?Id=" + Id);

                if (response.IsSuccessStatusCode)
                {

                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<UserModel>>(json_respuesta);
                    lista = resultado;
                }
            }

            return lista;
        }
        public async Task<UserModel> GetUser(int Id)
        {
            var lista = new UserModel();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/v1/User/GetUsers?usrId=" + Id);

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<UserModel>>(json_respuesta);
                lista = new UserModel
                {
                    usrId = resultado.FirstOrDefault().usrId,
                    usrName = resultado.FirstOrDefault().usrName,
                    usrLastName = resultado.FirstOrDefault().usrLastName,
                    usrAddres = resultado.FirstOrDefault().usrAddres,
                    usrEmail = resultado.FirstOrDefault().usrEmail,
                    usrCelPhone = resultado.FirstOrDefault().usrCelPhone,
                    rolId = resultado.FirstOrDefault().rolId,
                    createDate = resultado.FirstOrDefault().createDate,
                    createUser = resultado.FirstOrDefault().createUser,
                    modifyDate = resultado.FirstOrDefault().modifyDate,
                    modifyUser = resultado.FirstOrDefault().modifyUser
             
                };
            }

            return lista;
        }
        public async Task<bool> AddUser(UserModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/User/CreateUser", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpUser(UserModel obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/v1/User/UpdateUser", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


    }
}
