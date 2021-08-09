using Confitec.Cadastro.Models.Base;
using Confitec.Cadastro.Models.Interfaces;
using Confitec.Cadastro.Models.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Confitec.Cadastro.Services.Base
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidation, TModel>(TValidation validacao, TModel entidade) where TValidation : AbstractValidator<TModel> where TModel : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
