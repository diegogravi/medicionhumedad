﻿namespace MedicionHumedad.Data.UnitofWork
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MedicionHumedad.Data.Entity;
    using MedicionHumedad.Data.Repository;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        
        bool Save();

        Task<bool> SaveAsync();

        MedicionHumedadDBContext Context { get; }
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }

    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> _repositoriesAsync;
        private Dictionary<Type, object> _repositories;
        private bool _disposed;

        public MedicionHumedadDBContext Context { get; }

        public UnitOfWork(MedicionHumedadDBContext context)
        {
            Context = context;
            _disposed = false;
        }

        //public UnitOfWork()
        //{
        //    DbContextOptionsBuilder<MedicionHumedadDBContext> optionsBuilder = new DbContextOptionsBuilder<MedicionHumedadDBContext>();
        //    optionsBuilder.UseSqlServer("Server=LAPTOP-DIEGO;Database=MedicionHumedadDB;Trusted_Connection=True;");
        //    Context = new MedicionHumedadDBContext(optionsBuilder.Options);
        //    _disposed = false;
        //}

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(this);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_repositoriesAsync == null)
            {
                _repositoriesAsync = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositoriesAsync.ContainsKey(type))
            {
                _repositoriesAsync[type] = new RepositoryAsync<TEntity>(this);
            }

            return (IRepositoryAsync<TEntity>)_repositoriesAsync[type];
        }


        public bool Save()
        {
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
