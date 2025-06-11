using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services.DocumentServices;
using WebAppPayBill.Services.Enterprise;

namespace WebAppPayBill.Controllers
{
    public class EnterpriseController : Controller
    {
        private IEnterpriseService _servicioApi;
        private readonly ILogger<EnterpriseController> _logger;

        public EnterpriseController(ILogger<EnterpriseController> logger, IEnterpriseService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> EnterpriseList(EnterpriseModel obj)
        {
            List<EnterpriseModel> lista = await _servicioApi.GetEnterprises(obj.entId);
            return View(lista);

        }
        public async Task<IActionResult> AddEnterprise(EnterpriseModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddEnterprise(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EnterpriseList");
            else
                //return NoContent();
                return RedirectToAction("EnterpriseAdd");

        }
        public async Task<IActionResult> UpEnterprise(EnterpriseModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.modifyDate = DateTime.Now;
                obj.modifyUser = "Sistema";
                respuesta = await _servicioApi.UpEnterprise(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EnterpriseList");
            else
                //return NoContent();
                return RedirectToAction("EnterpriseAdd");

        }

        public IActionResult EnterpriseAdd()
        {
            return View();
        }
        public async Task<IActionResult> EnterpriseUp(EnterpriseModel obj)
        {
            EnterpriseModel lista = await _servicioApi.GetEnterprise(obj.entId);
            return View(lista);

        }
    }
}
