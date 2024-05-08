using EDCCC.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Infraestructure.Persistence
{
    public class EDCDbContext : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=EDCCC;Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}


        public EDCDbContext(DbContextOptions<EDCDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Date = DateTime.Now;
                        entry.Entity.ModifyDate = null;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyDate = DateTime.Now;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Customers>? customers { get; set; }
        public DbSet<TypeAccount>? typeAccounts { get; set; }
        public DbSet<Account>? accounts { get; set; }

        public DbSet<CCard>? ccards { get; set; }
        public DbSet<Bill>? bills { get; set; }

    



    }


}
