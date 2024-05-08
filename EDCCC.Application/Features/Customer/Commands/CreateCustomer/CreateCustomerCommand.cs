using MediatR;

namespace EDCCC.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {

        public string Name { get; set; }





    }
}
