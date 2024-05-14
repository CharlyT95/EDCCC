using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Command.CreateCCard
{
    public class CreateCCardCommandHandler : IRequestHandler<CreateCCardCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCCardCommandHandler> _logger;

        public CreateCCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCCardCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCCardCommand request, CancellationToken cancellationToken)
        {
            var CCardEntity = _mapper.Map<CCard>(request);
            _unitOfWork.Repository<CCard>().AddEntity(CCardEntity);
            var result = await _unitOfWork.Complete();

            if (result == 0)
            {
                throw new Exception($"No se pudo insertar tarjeta nueva");
            }

            _logger.LogInformation($"Tarjeta Numero: {CCardEntity.Id} fue creado con exito.");

            return CCardEntity.Id;
        }
    }
}
