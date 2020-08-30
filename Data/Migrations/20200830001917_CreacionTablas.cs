using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EjemploMVCCursosOnline.Data.Migrations
{
    public partial class CreacionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 256, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 256, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioCreacion = table.Column<string>(maxLength: 256, nullable: false),
                    UsuarioModificacion = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(maxLength: 256, nullable: false),
                    Profesion = table.Column<string>(maxLength: 256, nullable: false),
                    Cargo = table.Column<string>(maxLength: 256, nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioCreacion = table.Column<string>(maxLength: 256, nullable: false),
                    UsuarioModificacion = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextoComentario = table.Column<string>(maxLength: 256, nullable: false),
                    NombrePersona = table.Column<string>(maxLength: 256, nullable: false),
                    Puntaje = table.Column<decimal>(type: "decimal(3, 1)", nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioCreacion = table.Column<string>(maxLength: 256, nullable: false),
                    UsuarioModificacion = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioNormal = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioCreacion = table.Column<string>(maxLength: 256, nullable: false),
                    UsuarioModificacion = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precio_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoInstructor",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UsuarioCreacion = table.Column<string>(maxLength: 256, nullable: false),
                    UsuarioModificacion = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInstructor", x => new { x.CursoId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_CursoInstructor_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoInstructor_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_CursoId",
                table: "Comentario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstructor_InstructorId",
                table: "CursoInstructor",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_CursoId",
                table: "Precio",
                column: "CursoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "CursoInstructor");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
