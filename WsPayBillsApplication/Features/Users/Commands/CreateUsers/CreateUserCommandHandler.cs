using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Users.Commands.CreateUsers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<User>().GetFirstOrDefaultAsync(x => x.usrName == request.usrName);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<User>(request);
                var EntityAdd = await _unitOfWork.Repository<User>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<User>(EntityAdd);

                _logger.LogInformation($"El usuario fue creado con el id {EntityAdd.usrId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El usuario {request.usrName} no fue creado");

                return resp = false;
            }
        }
    }
}
