using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services.Enterprise;
using WebAppPayBill.Services.EnterpriseType;

namespace WebAppPayBill.Controllers
{
    public class EnterpriseTypeController : Controller
    {
        private IEnterpriseTypeService _servicioApi;
        private readonly ILogger<EnterpriseTypeController> _logger;

        public EnterpriseTypeController(ILogger<EnterpriseTypeController> logger, IEnterpriseTypeService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> EnterpriseTypeList(EnterpriseTypeModel obj)
        {
            List<EnterpriseTypeModel> lista = await _servicioApi.GetEnterpriseTypes(obj.etyId);
            return View(lista);

        }
        public async Task<IActionResult> AddEnterpriseType(EnterpriseTypeModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddEnterpriseType(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EnterpriseTypeList");
            else
                //return NoContent();
                return RedirectToAction("EnterpriseTypeAdd");

        }
        public async Task<IActionResult> UpEnterpriseType(EnterpriseTypeModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.UpEnterpriseType(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EnterpriseTypeList");
            else
                //return NoContent();
                return RedirectToAction("EnterpriseTypeAdd");

        }

        public IActionResult EnterpriseTypeAdd()
        {
            return View();
        }
        public async Task<IActionResult> EnterpriseTypeUp(EnterpriseTypeModel obj)
        {
            EnterpriseTypeModel lista = await _servicioApi.GetEnterpriseType(obj.etyId);
            return View(lista);

        }
    }
}
