﻿using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using EDCCC.Infraestructure.Persistence;
using System.Collections;

namespace EDCCC.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly EDCDbContext _context;
        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        public UnitOfWork(EDCDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
