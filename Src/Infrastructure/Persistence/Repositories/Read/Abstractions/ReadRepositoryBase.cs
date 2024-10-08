﻿using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using Persistence.Repositories.Abstractions;

namespace Persistence.Repositories.Read.Abstractions;

public abstract class ReadRepositoryBase<TEntity> : RepositoryBase<TEntity>, IReadRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected ReadRepositoryBase(ReadDbContext context) : base(context) { }

    public async Task<TEntity?> GetAsync(long id)
    {
        return await _set.FirstOrDefaultAsync(x => x.Id == id);
    }
}
