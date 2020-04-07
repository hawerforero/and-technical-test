using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApiAND.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActivos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    TipoActivoId = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activos_TipoActivos_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "TipoActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoMovimientoId = table.Column<int>(nullable: false),
                    ActivoId = table.Column<long>(nullable: false),
                    PersonaId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimientos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimientos_TipoMovimientos_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "TipoMovimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Planeación" },
                    { 2, "Desarrollo" },
                    { 3, "Personal" },
                    { 4, "Presupuesto" },
                    { 5, "Bienestar" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Rocio Suarez Sanchez" },
                    { 3, "Maria Jose Forero Suarez" },
                    { 4, "Juan Felipe Forero Suarez" },
                    { 1, "Hawer Forero Rey" },
                    { 2, "Juan Camilo Forero Rey" }
                });

            migrationBuilder.InsertData(
                table: "TipoActivos",
                columns: new[] { "Id", "Nombre", "Sigla" },
                values: new object[,]
                {
                    { 1L, "Equipos de comunicación y computación", "ECC" },
                    { 2L, "Muebles, Enseres, y Equipos de Oficina", "MEE" },
                    { 3L, "Cableado estructurado", "CE" },
                    { 4L, "Intangibles", "I" },
                    { 5L, "Equipo de transporte, tracción y elevación", "ETE" }
                });

            migrationBuilder.InsertData(
                table: "TipoMovimientos",
                columns: new[] { "Id", "Nombre", "Sigla" },
                values: new object[,]
                {
                    { 1, "Asignación", "ASI" },
                    { 2, "Devolución", "DEV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_TipoActivoId",
                table: "Activos",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ActivoId",
                table: "Movimientos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_AreaId",
                table: "Movimientos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_PersonaId",
                table: "Movimientos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TipoMovimientoId",
                table: "Movimientos",
                column: "TipoMovimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoMovimientos");

            migrationBuilder.DropTable(
                name: "TipoActivos");
        }
    }
}
