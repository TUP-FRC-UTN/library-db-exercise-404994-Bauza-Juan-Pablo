using Library.Context;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Impl
{
    public class GeneroRepository : IGeneroRepository
    {
        public readonly LibreriaContext _libreriaContext;

        public GeneroRepository(LibreriaContext context)
        {
            _libreriaContext = context;
        }

        public Task<List<Genero>> GetAllAsync()
        {
            return _libreriaContext.Generos.ToListAsync();
        }
    }
}
