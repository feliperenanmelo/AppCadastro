using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Models.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<List<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task<List<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate);
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(int id);
    }
}
