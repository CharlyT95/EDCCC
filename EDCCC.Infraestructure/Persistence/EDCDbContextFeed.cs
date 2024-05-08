using EDCCC.Domain;
using Microsoft.Extensions.Logging;

namespace EDCCC.Infraestructure.Persistence
{
    public class EDCDbContextFeed
    {
        private readonly EDCDbContext _context;
        private readonly ILogger<EDCDbContext> _logger;

        public EDCDbContextFeed(EDCDbContext context, ILogger<EDCDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task FeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.customers!.Any())
            {
                _context.customers!.AddRange(GetPreconfiguredCustomers());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando Clientes DB {_context}", typeof(EDCDbContext).Name);
            }

            if (!_context.typeAccounts!.Any())
            {
                _context.typeAccounts!.AddRange(GetPreconfiguredTypeAccounts());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando Tipos de cuenta");
            }

            if (!_context.accounts!.Any())
            {
                _context.accounts!.AddRange(GetPreconfiguredAccount());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando Cuentas");
            }

            if (!_context.ccards!.Any())
            {
                _context.ccards!.AddRange(GetPreconfiguredCCards());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando tarjetas");
            }

            if (!_context.bills!.Any())
            {
                _context.bills!.AddRange(GetPreconfiguredBills());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando gastos");
            }


        }


        private static IEnumerable<Customers> GetPreconfiguredCustomers() 
        {
            return new List<Customers>
            {
                new Customers { Name= "Omarin Activan de la O" },
                new Customers { Name= "Charly Mohammed Uhud"},
                new Customers { Name= "Mario Esteban Ledesma"},
                new Customers { Name= "Alondra Nohemi Najarro"}
            };
        }


        private static IEnumerable<TypeAccount> GetPreconfiguredTypeAccounts() 
        {
            return new List<TypeAccount>
            {
                new TypeAccount { Name="AHORRO"},
                new TypeAccount { Name="CORRIENTE"}
            };
        }

        private static IEnumerable<Account> GetPreconfiguredAccount()
        {
            return new List<Account>
            {
                new Account {CustomerId=1,Number=100,TypeAccountId=1},
                new Account {CustomerId=4,Number=101,TypeAccountId=2}
            };

        }

        private static IEnumerable<CCard> GetPreconfiguredCCards() 
        {

            return new List<CCard>
            {
                new CCard { AccountId=1,CNumber="0987 6534 6789 0012",InterestRate=0.36,Limit=2000.00},
                new CCard { AccountId=2,CNumber="0567 8900 4511 2345",InterestRate=0.24,Limit=4000.00}
            };
        }


        private static IEnumerable<Bill> GetPreconfiguredBills()
        {
            return new List<Bill>
            {
                new Bill {CCardId=1,Amount=15.00,Description="ADOC ZAP/2 503QWERTY" },
                new Bill {CCardId=1,Amount=200.00,Description="Super selecto SOYSS1101" },
                new Bill {CCardId=1,Amount=25.99,Description="EARPHONES SIMAN 120124" },
                new Bill {CCardId=2,Amount=299.99,Description="NINTENDO SWITCH ZDSOY" }
            };
        }

        

    }
}
