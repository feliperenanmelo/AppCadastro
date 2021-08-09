using Confitec.Cadastro.Models;
using Confitec.Cadastro.Models.Interfaces;
using Confitec.Cadastro.Models.Validacoes;
using Confitec.Cadastro.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, 
                              INotificador notificador) 
            : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObterTodos() => await _usuarioRepository.ObterTodos();

        public async Task<Usuario> ObterPorId(int id) => await _usuarioRepository.ObterPorId(id);

        public async Task<List<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate) =>        
                await _usuarioRepository.Buscar(predicate);        

        public async Task<bool> Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            await _usuarioRepository.Adicionar(usuario);

            return true;
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            await _usuarioRepository.Atualizar(usuario);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _usuarioRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}
