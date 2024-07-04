using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
