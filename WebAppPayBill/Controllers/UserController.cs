using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppPayBill.Models;
using WebAppPayBill.Services.User;

namespace WebAppPayBill.Controllers
{
    public class UserController : Controller
    {
        private IUserService _servicioApi;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> UserList(UserModel obj)
        {
            List<UserModel> lista = await _servicioApi.GetUsers(obj.usrId);
            return View(lista);

        }
        public async Task<IActionResult> AddUser(UserModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                obj.State = 1;
                obj.modifyDate = DateTime.Now;
                obj.modifyUser = "Sistema";
                respuesta = await _servicioApi.AddUser(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("UserList");
            else
                //return NoContent();
                return RedirectToAction("UserAdd");

        }
        public async Task<IActionResult> UpUser(UserModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                obj.State = 1;
                obj.modifyDate = DateTime.Now;
                obj.modifyUser = "Sistema";
                respuesta = await _servicioApi.UpUser(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("UserList");
            else
                //return NoContent();
                return RedirectToAction("UserAdd");

        }

        public IActionResult UserAdd()
        {
            return View();
        }
        public async Task<IActionResult> UserUp(UserModel obj)
        {
            UserModel lista = await _servicioApi.GetUser(obj.usrId);
            return View(lista);

        }
    }
}
