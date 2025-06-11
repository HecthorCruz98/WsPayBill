using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppPayBill.Models;
using WebAppPayBill.Services;

namespace WebAppPayBill.Controllers
{
    public class BillController : Controller
    {
        private IBillService _servicioApi;
        private readonly ILogger<BillController> _logger;

        public BillController(ILogger<BillController> logger, IBillService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> BillList(BillModel obj)
        {
            List<BillModel> lista = await _servicioApi.GetBills(obj.bilId);
            return View(lista);

        }
        public async Task<IActionResult> AddBill(BillModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddBill(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("BillList");
            else
                //return NoContent();
                return RedirectToAction("BillAdd");

        }
        public async Task<IActionResult> UpBill(BillModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                obj.State = 1;
                obj.updateDate = DateTime.Now;
                obj.updateUser = "Sistema";
                respuesta = await _servicioApi.UpBill(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("BillList");
            else
                //return NoContent();
                return RedirectToAction("BillAdd");

        }

        public IActionResult BillAdd()
        {
            return View();
        }
        public async Task<IActionResult> BillUp(int bilNumber)
        {
            BillModel lista = await _servicioApi.GetBill(bilNumber);
            return View(lista);

        }
    }
}
