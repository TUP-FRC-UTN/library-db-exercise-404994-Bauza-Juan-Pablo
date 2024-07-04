using Library.Context;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Impl
{
    public class AutorRepository : IAutorRepository
    {
        public readonly LibreriaContext _libreriaContext;

        public AutorRepository(LibreriaContext context)
        {
            _libreriaContext = context;
        }
        public Task<List<Autor>> GetAllAsync()
        {
            return _libreriaContext.Autores.ToListAsync();
        }
    }
}
