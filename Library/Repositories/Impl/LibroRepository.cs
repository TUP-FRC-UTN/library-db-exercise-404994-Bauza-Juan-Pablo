using Library.Context;
using Library.Domain;
using Library.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Impl
{
    public class LibroRepository : ILibroRepository
    {
        public readonly LibreriaContext _libreriaContext;
        public LibroRepository(LibreriaContext context)
        {
            _libreriaContext = context;
        }
        public async Task<Libro> CreateAsync(Libro libro)
        {
            _libreriaContext.Libros.Add(libro);
            await _libreriaContext.SaveChangesAsync();
            return libro;
        }

        public async Task<bool> DeleteAsync(int isbn)
        {
            var libro = await _libreriaContext.Libros.FirstOrDefaultAsync(libro => libro.ISBN == isbn);
            if(libro != null)
            {
                _libreriaContext.Libros.Remove(libro);
                await _libreriaContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<List<Libro>> GetAllAsync()
        {
            return _libreriaContext.Libros
                              .Include(p => p.Autor)
                              .Include(p => p.Genero)
                              .ToListAsync();
        }

        public async Task<Libro> GetByIdAsync(int isbn)
        {
            return await _libreriaContext.Libros.FirstOrDefaultAsync(libro => libro.ISBN == isbn);
        }

        public async Task<Libro> UpdateAsync(Libro libro)
        {
            if (libro == null)
            {
                throw new ArgumentNullException(nameof(libro));
            }
            _libreriaContext.Libros.Update(libro);
            await _libreriaContext.SaveChangesAsync();
            return libro;
        }
    }
}
