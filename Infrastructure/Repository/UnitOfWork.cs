﻿using Application.Persistence;
using Application.Repository;
using Infrastructure.Persistencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable? _repositories;

        private readonly EcommerceDbContext _context;


        public UnitOfWork(EcommerceDbContext context) 
        {
            _context = context;

        }
        public async Task<int> Complete()
        {
         try
            {
                return await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                throw new Exception("Error en transaccion", e);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)));
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
