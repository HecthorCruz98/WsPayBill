using Microsoft.AspNetCore.Mvc;
using WebAppPayBill.Models;
using WebAppPayBill.Services;
using WebAppPayBill.Services.DocumentServices;

namespace WebAppPayBill.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentService _servicioApi;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public async Task<IActionResult> DocumentList(DocumentModel obj)
        {
            List<DocumentModel> lista = await _servicioApi.GetDocuments(obj.bilId);
            return View(lista);

        }
        public async Task<IActionResult> AddDocument(DocumentModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.createDate = DateTime.Now;
                obj.createUser = "Sistema";
                respuesta = await _servicioApi.AddDocument(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("DocumentList");
            else
                //return NoContent();
                return RedirectToAction("DocumentAdd");

        }
        public async Task<IActionResult> UpDocument(DocumentModel obj)
        {

            bool respuesta;

            if (obj != null)
            {
                //obj.State = 1;
                obj.modifyDate = DateTime.Now;
                obj.modifyUser = "Sistema";
                respuesta = await _servicioApi.UpDocument(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("DocumentList");
            else
                //return NoContent();
                return RedirectToAction("DocumentAdd");

        }

        public IActionResult DocumentAdd()
        {
            return View();
        }
        public async Task<IActionResult> DocumentUp(DocumentModel obj)
        {
            DocumentModel lista = await _servicioApi.GetDocument(obj.docId);
            return View(lista);

        }
    }
}
