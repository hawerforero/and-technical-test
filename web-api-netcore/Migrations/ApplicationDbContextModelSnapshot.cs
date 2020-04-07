﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiAND.Contexts;

namespace WebApiAND.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApiAND.Entities.Activo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Estado");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nombre");

                    b.Property<string>("Serial");

                    b.Property<long>("TipoActivoId");

                    b.Property<string>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("TipoActivoId");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("WebApiAND.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Planeación"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Desarrollo"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Personal"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Presupuesto"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Bienestar"
                        });
                });

            modelBuilder.Entity("WebApiAND.Entities.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ActivoId");

                    b.Property<int?>("AreaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Observacion");

                    b.Property<int?>("PersonaId");

                    b.Property<int>("TipoMovimientoId");

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("AreaId");

                    b.HasIndex("PersonaId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("WebApiAND.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Hawer Forero Rey"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Juan Camilo Forero Rey"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Maria Jose Forero Suarez"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Juan Felipe Forero Suarez"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Rocio Suarez Sanchez"
                        });
                });

            modelBuilder.Entity("WebApiAND.Entities.TipoActivo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.Property<string>("Sigla");

                    b.HasKey("Id");

                    b.ToTable("TipoActivos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nombre = "Equipos de comunicación y computación",
                            Sigla = "ECC"
                        },
                        new
                        {
                            Id = 2L,
                            Nombre = "Muebles, Enseres, y Equipos de Oficina",
                            Sigla = "MEE"
                        },
                        new
                        {
                            Id = 3L,
                            Nombre = "Cableado estructurado",
                            Sigla = "CE"
                        },
                        new
                        {
                            Id = 4L,
                            Nombre = "Intangibles",
                            Sigla = "I"
                        },
                        new
                        {
                            Id = 5L,
                            Nombre = "Equipo de transporte, tracción y elevación",
                            Sigla = "ETE"
                        });
                });

            modelBuilder.Entity("WebApiAND.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.Property<string>("Sigla");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimientos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Asignación",
                            Sigla = "ASI"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Devolución",
                            Sigla = "DEV"
                        });
                });

            modelBuilder.Entity("WebApiAND.Entities.Activo", b =>
                {
                    b.HasOne("WebApiAND.Entities.TipoActivo", "TipoActivo")
                        .WithMany()
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiAND.Entities.Movimiento", b =>
                {
                    b.HasOne("WebApiAND.Entities.Activo", "Activo")
                        .WithMany()
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiAND.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("WebApiAND.Entities.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.HasOne("WebApiAND.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany()
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
