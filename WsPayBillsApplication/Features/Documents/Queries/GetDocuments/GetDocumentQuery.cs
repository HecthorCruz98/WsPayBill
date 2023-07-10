using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetDocuments;

namespace WsPayBillsApplication.Features.Documents.Queries.GetDocuments
{
    public class GetDocumentQuery : IRequest<List<DocumentsVm>>
    {
        public GetDocumentQuery(int? docId)
        {
            DocId = docId;
        }
        public int? DocId { get; set; }

    }
}
