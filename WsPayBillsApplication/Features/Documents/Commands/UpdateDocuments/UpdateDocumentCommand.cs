using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Documents.Commands.UpdateDocuments
{
    public class UpdateDocumentCommand : IRequest<bool>
    {
        public int docId { get; set; }
        public int usrId { get; set; }
        public int bilId { get; set; }
        public string docUrl { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }

    }
}
