using MediatR;

namespace EDCCC.Application.Features.Customer.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersVm>>
    {
        public string _Name { get; set; }

        public GetCustomersListQuery(string name)
        {
            _Name = name ?? throw new ArgumentNullException(nameof(name));
        }



    }
}
