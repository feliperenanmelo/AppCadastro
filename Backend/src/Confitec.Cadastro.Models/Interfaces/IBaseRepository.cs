using Confitec.Cadastro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Models.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(int id);        
        Task<int> SaveChanges();
    }
}
