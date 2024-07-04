using Library.Domain;


namespace Library.Repositories
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllAsync();
        Task<Libro> GetByIdAsync(int isbn);
        Task<Libro> CreateAsync(Libro libro);
        Task<Libro> UpdateAsync(Libro libro);
        Task<bool> DeleteAsync(int isbn);
    }
}
