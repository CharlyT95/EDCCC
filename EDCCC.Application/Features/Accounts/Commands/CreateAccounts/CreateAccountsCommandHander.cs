using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Commands.CreateAccounts
{
    public class CreateAccountsCommandHander : IRequestHandler<CreateAccountsCommand, int>
    {
        private readonly ILogger<CreateAccountsCommandHander> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountsCommandHander(ILogger<CreateAccountsCommandHander> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAccountsCommand request, CancellationToken cancellationToken)
        {
            var AccountEntity = _mapper.Map<Account>(request);
            _unitOfWork.Repository<Account>().AddEntity(AccountEntity);
            var result = await _unitOfWork.Complete();

            if (result == 0)
            {
                _logger.LogError("Error en insercion de cuenta"); throw new Exception("Error en nueva cuenta");
            }

            return AccountEntity.Id;
        }
    }
}
