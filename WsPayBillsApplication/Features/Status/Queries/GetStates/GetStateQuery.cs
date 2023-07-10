using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetStateVm;

namespace WsPayBillsApplication.Features.Status.Queries.GetStates
{
    public class GetStateQuery : IRequest<List<StateVm>>
    {
        public GetStateQuery(int? staId)
        {
            staId = StaId;
        }
        public int? StaId { get; set; }
    }
}
