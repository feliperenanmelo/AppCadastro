using Confitec.Cadastro.Data.Context;
using Confitec.Cadastro.Models.Base;
using Confitec.Cadastro.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Data.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ConfitecDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(ConfitecDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ObterTodos() => await DbSet.AsNoTracking().ToListAsync();

        public virtual async Task<TEntity> ObterPorId(int id) => 
            await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {   
            DbSet.Add(entity);

            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);

            await SaveChanges();
        }

        public virtual async Task Remover(int id)
        {
            DbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await Context.SaveChangesAsync();

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
