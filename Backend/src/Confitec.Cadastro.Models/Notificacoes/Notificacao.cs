namespace Confitec.Cadastro.Models.Notificacoes
{
    public class Notificacao
    {
        public string Mensagem { get; set; }
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
