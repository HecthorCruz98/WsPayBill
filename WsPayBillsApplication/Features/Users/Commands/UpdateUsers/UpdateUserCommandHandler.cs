using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Users.Commands.UpdateUsers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<User>().GetFirstOrDefaultAsync(x => x.usrId == request.usrId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.usrName = request.usrName;
                VerifiData.usrLastName = request.usrLastName;
                VerifiData.usrAddres = request.usrAddres;
                VerifiData.usrEmail = request.usrEmail;
                VerifiData.usrCelPhone = request.usrCelPhone;
                VerifiData.rolId = request.rolId;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<User>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El usuario {request.usrId} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El usuario {request.usrId} no fue actualizado");

                return resp = false;
            }
        }
    }
}
