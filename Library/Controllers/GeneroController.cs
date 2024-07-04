using Library.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetLibrosAsync()
        {
            var generos = await _generoRepository.GetAllAsync();
            return Ok(generos);
        }
    }
}
