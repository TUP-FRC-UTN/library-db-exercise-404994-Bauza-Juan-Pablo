using Library.Domain;

namespace Library.Repositories
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetAllAsync();
    }
}
