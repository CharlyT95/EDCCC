using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Application.Exceptions;
using EDCCC.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Command.UpdateCCard
{
    public class UpdateCCardCommandHandler : IRequestHandler<UpdateCCardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCCardCommandHandler> _logger;

        public UpdateCCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCCardCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCCardCommand request, CancellationToken cancellationToken)
        {
            var CCardUpdate = await _unitOfWork.Repository<CCard>().GetByIdAsync(request.Id);

            if (CCardUpdate == null)
            {
                _logger.LogError($"Id no encontrado {request.Id}");
                throw new NotFoundException(nameof(CCard), request.Id);
            }

            _mapper.Map(request, CCardUpdate, typeof(UpdateCCardCommand), typeof(CCard));

            _unitOfWork.Repository<CCard>().UpdateEntity(CCardUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Actualizacion de tarjeta exitosa  {request.Id}");

            return Unit.Value;
        }
    }
}
