using AutoMapper;
using Confitec.Cadastro.Api.Controllers.Base;
using Confitec.Cadastro.Api.ViewModel;
using Confitec.Cadastro.Models;
using Confitec.Cadastro.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IMapper mapper,
            IUsuarioService usuarioService,
            INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpGet("Obter-Todos")]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioService.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(int id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null) return NotFound();

            return usuarioViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            await _usuarioService.Adicionar(usuario);

            var usuarioInserido = _usuarioService
                .Buscar(usu => usu.Nome == usuarioViewModel.Nome &&
                               usu.Sobrenome == usuarioViewModel.Sobrenome &&
                               usu.Email == usuarioViewModel.Email &&
                               usu.DataNascimento == usuarioViewModel.DataNascimento &&
                               usu.Escolaridade == usuarioViewModel.Escolaridade).Result.First();

            return ResponseCustomizado(_mapper.Map<UsuarioViewModel>(usuarioInserido));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Atualizar(int id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return ResponseCustomizado();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await ObterUsuario(id);

            usuario.Nome = usuarioViewModel.Nome;
            usuario.Sobrenome = usuarioViewModel.Sobrenome;
            usuario.Email = usuarioViewModel.Email;
            usuario.DataNascimento = usuarioViewModel.DataNascimento;
            usuario.Escolaridade = usuarioViewModel.Escolaridade;

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuario));

            return ResponseCustomizado(usuarioViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Remover(int id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null) return NotFound();

            await _usuarioService.Remover(id);

            return ResponseCustomizado(usuarioViewModel);
        }

        private async Task<UsuarioViewModel> ObterUsuario(int id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioService.ObterPorId(id));
        }
    }
}