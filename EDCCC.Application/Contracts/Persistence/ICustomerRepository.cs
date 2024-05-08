using EDCCC.Domain;

namespace EDCCC.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customers>
    {
        Task<IEnumerable<Customers>> GetCustomerByName(string customerName);

        Task<IEnumerable<Customers>> GetCustomerByName(DateTime created);


    }
}
