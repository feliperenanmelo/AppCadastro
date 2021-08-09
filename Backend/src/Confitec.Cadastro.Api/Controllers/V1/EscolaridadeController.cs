using Confitec.Cadastro.Api.Controllers.Base;
using Confitec.Cadastro.Models;
using Confitec.Cadastro.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Confitec.Cadastro.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : MainController
    {
        private readonly INotificador _notificador;

        public EscolaridadeController(INotificador notificador) 
            : base(notificador)
        {
            _notificador = notificador;
        }

        [HttpGet("Obter-Todos")]
        public IEnumerable<Escolaridade> Obtertodos()
        {
            return Escolaridade.ObterTodas();
        }
    }
}