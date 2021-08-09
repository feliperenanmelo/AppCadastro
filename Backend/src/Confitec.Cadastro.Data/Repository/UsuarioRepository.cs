using Confitec.Cadastro.Data.Context;
using Confitec.Cadastro.Data.Repository.Base;
using Confitec.Cadastro.Models;
using Confitec.Cadastro.Models.Interfaces;

namespace Confitec.Cadastro.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecDbContext context): base(context)
        { }
    }
}
