using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services.State;
using WebAppPayBill.Services.Transaction;

namespace WebAppPayBill.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionService _servicioApi;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> TransactionList(TransactionModel obj)
        {
            List<TransactionModel> lista = await _servicioApi.GetTransactions(obj.trnId);
            return View(lista);

        }
        public async Task<IActionResult> AddTransaction(TransactionModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddTransaction(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("TransactionList");
            else
                //return NoContent();
                return RedirectToAction("TransactionAdd");

        }
        public async Task<IActionResult> UpTransaction(TransactionModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.UpTransaction(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("TransactionList");
            else
                //return NoContent();
                return RedirectToAction("TransactionAdd");

        }

        public IActionResult TransactionAdd()
        {
            return View();
        }
        public async Task<IActionResult> TransactionUp(TransactionModel obj)
        {
            List<TransactionModel> lista = await _servicioApi.GetTransactions(obj.trnId);
            return View(lista);

        }
    }
}
