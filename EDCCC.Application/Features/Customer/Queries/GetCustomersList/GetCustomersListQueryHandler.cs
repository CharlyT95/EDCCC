using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using MediatR;

namespace EDCCC.Application.Features.Customer.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersVm>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomersVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var CustomerList = await _customerRepository.GetCustomerByName(request._Name);

            return _mapper.Map<List<CustomersVm>>(CustomerList);

        }
    }
}
