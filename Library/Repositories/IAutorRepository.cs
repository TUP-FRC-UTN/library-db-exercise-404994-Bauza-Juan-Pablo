using Library.Domain;

namespace Library.Repositories
{
    public interface IAutorRepository
    {
        Task<List<Autor>> GetAllAsync();
    }
}
