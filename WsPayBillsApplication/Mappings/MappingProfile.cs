using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsApplication.Features.Documents.Commands.CreateDocuments;
using WsPayBillsApplication.Features.Documents.Commands.UpdateDocuments;
using WsPayBillsApplication.Features.Enterprises.Commands.CreateEnterprises;
using WsPayBillsApplication.Features.Enterprises.Commands.UpdateEnterprises;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes;
using WsPayBillsApplication.Features.Roles.Commands.CreateRoles;
using WsPayBillsApplication.Features.Roles.Commands.UpdateRoles;
using WsPayBillsApplication.Features.Status.Commands.CreateStates;
using WsPayBillsApplication.Features.Status.Commands.UpdateStates;
using WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions;
using WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction;
using WsPayBillsApplication.Features.Users.Commands.CreateUsers;
using WsPayBillsApplication.Features.Users.Commands.UpdateUsers;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetDocuments;
using WsPayBillsApplication.Models.BillsVm.GetEnterprise;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsApplication.Models.BillsVm.GetStateVm;
using WsPayBillsApplication.Models.BillsVm.GetTransactionVm;
using WsPayBillsApplication.Models.BillsVm.GetUserVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBillCommand, Bill>();
            CreateMap<UpdateBillCommand, Bill>();
            CreateMap<Bill, BillsVm>();

            CreateMap<CreateDocumentCommand, Document>();
            CreateMap<UpdateDocumentCommand, Document>();
            CreateMap<Document, DocumentsVm>();

            CreateMap<CreateEnterpriseCommand, Enterprise>();
            CreateMap<UpdateEnterpriseCommand, Enterprise>();
            CreateMap<Enterprise, EnterprisesVm>();

            CreateMap<CreateEnterpriseTypeCommand, EnterpriseType>();
            CreateMap<UpdateEnterpriseTypeCommand, EnterpriseType>();
            CreateMap<EnterpriseType, EnterpriseTypeVm>();

            CreateMap<CreateRolCommand, Rol>();
            CreateMap<UpdateRolCommand, Rol>();
            CreateMap<Rol, RolVm>();

            CreateMap<CreateStateCommand, State>();
            CreateMap<UpdateStateCommand, State>();
            CreateMap<State, StateVm>();

            CreateMap<CreateTransactionCommand, Transaction>();
            CreateMap<UpdateTransactionCommand, Transaction>();
            CreateMap<Transaction, TransactionVm>();

            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserVm>();
        }
    }
}
