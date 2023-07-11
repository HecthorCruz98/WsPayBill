using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services;
using WebAppPayBill.Services.Rol;

namespace WebAppPayBill.Controllers
{
    public class RolController : Controller
    {
        private IRolService _servicioApi;
        private readonly ILogger<RolController> _logger;

        public RolController(ILogger<RolController> logger, IRolService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> RolList(RolModel obj)
        {
            List<RolModel> lista = await _servicioApi.GetRoles(obj.rolId);
            return View(lista);

        }
        public async Task<IActionResult> AddRol(RolModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddRol(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("RolList");
            else
                //return NoContent();
                return RedirectToAction("RolAdd");

        }
        public async Task<IActionResult> UpRol(RolModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.UpRol(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("RolList");
            else
                //return NoContent();
                return RedirectToAction("RolAdd");

        }

        public IActionResult RolAdd()
        {
            return View();
        }
        public async Task<IActionResult> RolUp(RolModel obj)
        {
            List<RolModel> lista = await _servicioApi.GetRoles(obj.rolId);
            return View(lista);

        }
    }
}
