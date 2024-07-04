using Library.Domain;
using Library.Dtos;
using Library.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;
        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetLibrosAsync()
        {
            var libros = await _libroRepository.GetAllAsync();
            return Ok(libros);
        }


        [HttpGet("getById/{isbn}")]
        public async Task<IActionResult> GetLibroById(int isbn)
        {
            var libro = await _libroRepository.GetByIdAsync(isbn);
            return Ok(libro);
        }


        [HttpPost("postOne")]
        public async Task<IActionResult> CreateLibrosAsync([FromBody] LibroDto dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                AutorId = dto.AutorId,
                FechaPublicacion = dto.FechaPublicacion,
                GeneroId = dto.GeneroId,
            };
            var response = await _libroRepository.CreateAsync(libro);
            return Ok(response);
        }


        [HttpDelete("delete/{isbn}")]
        public async Task<IActionResult> DeleteAsync(int isbn)
        {
            var response = await _libroRepository.DeleteAsync(isbn);
            return Ok(response);
        }


        [HttpPut("updateOne/{isbn}")]
        public async Task<IActionResult> UpdateAsync([FromBody] LibroDto dto, int isbn)
        {
            var libroModificado = await _libroRepository.GetByIdAsync(isbn);
            if(libroModificado != null)
            {
                libroModificado.Titulo = dto.Titulo;
                libroModificado.AutorId = dto.AutorId;
                libroModificado.FechaPublicacion = dto.FechaPublicacion;
                libroModificado.GeneroId = dto.GeneroId;
                var response = await _libroRepository.UpdateAsync(libroModificado);
                return Ok(response);
            }
            else throw new ArgumentNullException(nameof(isbn));
        }
    }
}
