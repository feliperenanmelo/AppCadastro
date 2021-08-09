using Confitec.Cadastro.Models.Notificacoes;
using System.Collections.Generic;

namespace Confitec.Cadastro.Models.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
