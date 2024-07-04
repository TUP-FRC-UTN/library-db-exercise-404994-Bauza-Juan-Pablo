using Library.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetLibrosAsync()
        {
            var generos = await _autorRepository.GetAllAsync();
            return Ok(generos);
        }
    }
}
