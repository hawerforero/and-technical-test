using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAND.Entities;

namespace WebApiAND.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Activo> Activos { get; set; }
        public DbSet<TipoActivo> TipoActivos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tipoActivos = new List<TipoActivo>()
            {
                new TipoActivo(){Id = 1, Nombre = "Equipos de comunicación y computación", Sigla = "ECC" },
                new TipoActivo(){Id = 2, Nombre = "Muebles, Enseres, y Equipos de Oficina", Sigla = "MEE" },
                new TipoActivo(){Id = 3, Nombre = "Cableado estructurado", Sigla = "CE" },
                new TipoActivo(){Id = 4, Nombre = "Intangibles", Sigla = "I" },
                new TipoActivo(){Id = 5, Nombre = "Equipo de transporte, tracción y elevación", Sigla = "ETE" }
            };
            modelBuilder.Entity<TipoActivo>().HasData(tipoActivos);

            var personas = new List<Persona>()
            {
                new Persona(){Id = 1, Nombre = "Hawer Forero Rey" },
                new Persona(){Id = 2, Nombre = "Juan Camilo Forero Rey" },
                new Persona(){Id = 3, Nombre = "Maria Jose Forero Suarez" },
                new Persona(){Id = 4, Nombre = "Juan Felipe Forero Suarez"},
                new Persona(){Id = 5, Nombre = "Rocio Suarez Sanchez"},
            };
            modelBuilder.Entity<Persona>().HasData(personas);

            var areas = new List<Area>()
            {
                new Area(){Id = 1, Nombre = "Planeación" },
                new Area(){Id = 2, Nombre = "Desarrollo" },
                new Area(){Id = 3, Nombre = "Personal" },
                new Area(){Id = 4, Nombre = "Presupuesto"},
                new Area(){Id = 5, Nombre = "Bienestar"},
            };
            modelBuilder.Entity<Area>().HasData(areas);

            var tipoMovimientos = new List<TipoMovimiento>()
            {
                new TipoMovimiento(){Id = 1, Nombre = "Asignación", Sigla = "ASI" },
                new TipoMovimiento(){Id = 2, Nombre = "Devolución", Sigla = "DEV" }
            };
            modelBuilder.Entity<TipoMovimiento>().HasData(tipoMovimientos);

            base.OnModelCreating(modelBuilder);
        }
    }
}
