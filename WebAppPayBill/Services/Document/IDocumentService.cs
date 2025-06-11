using WebAppPayBill.Models;

namespace WebAppPayBill.Services.DocumentServices
{
    public interface IDocumentService
    {
        Task<List<DocumentModel>> GetDocuments(int? Id);

        Task<DocumentModel> GetDocument(int Id);
        Task<bool> AddDocument(DocumentModel obj);
        Task<bool> UpDocument(DocumentModel obj);
    }
}
