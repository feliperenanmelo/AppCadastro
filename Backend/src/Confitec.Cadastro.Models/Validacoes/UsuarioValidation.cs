using FluentValidation;

namespace Confitec.Cadastro.Models.Validacoes
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Sobrenome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.DataNascimento)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório");
            
            RuleFor(u => Usuario.ValidarDataNascimentoInvalida(u.DataNascimento.Date))
                .Equal(false)
                .WithMessage("A data de nascimento não pode ser maior que hoje");

            RuleFor(u => u.Escolaridade)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório");
            
            RuleFor(u => Escolaridade.Existir(u.Escolaridade))
                .Equal(true)
                .WithMessage("Escolaridade inválida");

            RuleFor(c => c.Escolaridade)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
