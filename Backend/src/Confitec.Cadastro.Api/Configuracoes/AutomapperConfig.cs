using AutoMapper;
using Confitec.Cadastro.Api.ViewModel;
using Confitec.Cadastro.Models;

namespace Confitec.Cadastro.Api.Configuracoes
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
