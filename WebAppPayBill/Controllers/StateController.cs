using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services;
using WebAppPayBill.Services.State;

namespace WebAppPayBill.Controllers
{
    public class StateController : Controller
    {
        private IStateService _servicioApi;
        private readonly ILogger<BillController> _logger;

        public StateController(ILogger<BillController> logger, IStateService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> StateList(StateModel obj)
        {
            List<StateModel> lista = await _servicioApi.GetStates(obj.staId);
            return View(lista);

        }
        public async Task<IActionResult> AddState(StateModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddStates(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("StateList");
            else
                //return NoContent();
                return RedirectToAction("StateAdd");

        }
        public async Task<IActionResult> UpState(StateModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.UpStates(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("StateList");
            else
                //return NoContent();
                return RedirectToAction("StateAdd");

        }

        public IActionResult StateAdd()
        {
            return View();
        }
        public async Task<IActionResult> StateUp(StateModel obj)
        {
            List<StateModel> lista = await _servicioApi.GetStates(obj.staId);
            return View(lista);

        }
    }
}
