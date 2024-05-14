using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace EDCCC.Application.Features.Bills.Commands.CreateBills
{
    public class CreateBillsCommandHandler : IRequestHandler<CreateBillsCommand, int>
    {
        private readonly ILogger<CreateBillsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBillsCommandHandler(ILogger<CreateBillsCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBillsCommand request, CancellationToken cancellationToken)
        {
            var billEntity = _mapper.Map<Bill>(request);
            _unitOfWork.Repository<Bill>().AddEntity(billEntity);
            var result = await _unitOfWork.Complete();

            if (result == 0)
            {
                _logger.LogError("No se pudo insertar el dato");
                throw new Exception("No se pudo insertar el dato");
            }

            return billEntity.Id;
        }
    }
}
