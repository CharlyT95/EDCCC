using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using EDCCC.Domain;

namespace EDCCC.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customers>(request);
            var newCustomer = await _customerRepository.AddAsync(customerEntity);
            _logger.LogInformation($"Customer {newCustomer.Id} fue creado con éxito");

            return newCustomer.Id;

        }
    }
}
