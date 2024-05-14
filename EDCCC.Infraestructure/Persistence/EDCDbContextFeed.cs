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

            if (!_context.transactionType!.Any())
            {
                _context.transactionType!.AddRange(GetPreconfiguredTransactionTypes());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Registrando tipos de transaccion");
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

        private static IEnumerable<TransactionType> GetPreconfiguredTransactionTypes()
        {
            return new List<TransactionType>
            {
                new TransactionType { Name="CARGO"},
                new TransactionType { Name="ABONO"}
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
            System.DateTime date1 = new System.DateTime(2025, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2028, 7, 15, 6, 30, 20);
            return new List<CCard>
            {
                new CCard { AccountId=1,CNumber="0987653467890012",InterestRate=0.36,Limit=2000.00, DueDate=date1},
                new CCard { AccountId=2,CNumber="0567890045112345",InterestRate=0.24,Limit=4000.00,DueDate=date2}
            };
        }



        private static IEnumerable<Bill> GetPreconfiguredBills()
        {
            System.DateTime date1 = new System.DateTime(2024, 3, 4, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2024, 1, 1, 2, 15, 10);
            System.DateTime date3 = new System.DateTime(2024, 2, 2, 2, 15, 10);
            System.DateTime date4 = new System.DateTime(2024, 3, 3, 2, 15, 10);

            return new List<Bill>
            {
                new Bill {CCardId=1,Amount=15.00,Description="ADOC ZAP/2 503QWERTY", TransactionTypeId=1, Date= date1},
                new Bill {CCardId=1,Amount=200.00,Description="Super selecto SOYSS1101",TransactionTypeId=1 ,Date= date2},
                new Bill {CCardId=1,Amount=25.99,Description="EARPHONES SIMAN 120124",TransactionTypeId=1 ,Date= date3},
                new Bill {CCardId=2,Amount=299.99,Description="NINTENDO SWITCH ZDSOY",TransactionTypeId=1,Date= date4 }
            };
        }



        

    }
}
