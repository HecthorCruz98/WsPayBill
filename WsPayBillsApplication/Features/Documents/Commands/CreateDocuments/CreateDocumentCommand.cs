using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Documents.Commands.CreateDocuments
{
    public class CreateDocumentCommand : IRequest<bool>
    {
        public int usrId { get; set; }
        public int bilId { get; set; }
        public string docUrl { get; set; }
        public string createUser { get; set; }
    }
}
