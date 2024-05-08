using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using EDCCC.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Infraestructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customers>, ICustomerRepository
    {
        public CustomerRepository(EDCDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Customers>> GetCustomerByName(string customerName)
        {
            return await _context.customers!.Where(x => x.Name == (customerName)).ToListAsync();
        }

        public Task<IEnumerable<Customers>> GetCustomerByName(DateTime created)
        {
            throw new NotImplementedException();
        }
    }
}
