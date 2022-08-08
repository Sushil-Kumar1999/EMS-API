﻿using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Newtonsoft.Json;
using System;

namespace EMS.Persistence.EntityFrameworkCore
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EMSDbContext _context;

        public UnitOfWork(EMSDbContext context)
        {
            _context = context;
            _context.Database.BeginTransaction();
        }

        public void Rollback() => _context.Database.RollbackTransaction();

        public void Dispose() => _context?.Dispose();

        public T Clone<T>(T source)
        {
            string serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
