using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class LibreriaContext:DbContext
    {
        //Representan las tablas de la DB
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }

        //Constructor
        public LibreriaContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Se define la relacion entre las tablas
            modelBuilder.Entity<Libro>()
                .HasOne(p => p.Autor)
                .WithMany()
                .HasForeignKey(p => p.AutorId);

            modelBuilder.Entity<Libro>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.GeneroId);
        }

    }
}
