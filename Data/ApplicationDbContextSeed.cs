using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Data
{
    public class ApplicationDbContextSeed
    {

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Curso.Any())
            {

                var listaCurso = new List<Curso>()
                {
                    new Curso { Titulo = "Título del curso de prueba 1", Descripcion = "Descripción del curso de prueba 1", FechaPublicacion = DateTime.Parse("2020/08/29 12:10:01"), Precio = new Precio { PrecioNormal = 100000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 2", Descripcion = "Descripción del curso de prueba 2", FechaPublicacion = DateTime.Parse("2020/08/29 12:10:01"), Precio = new Precio { PrecioNormal = 200000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 3", Descripcion = "Descripción del curso de prueba 3", FechaPublicacion = DateTime.Parse("2020/08/29 12:13:01"), Precio = new Precio { PrecioNormal = 300000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 4", Descripcion = "Descripción del curso de prueba 4", FechaPublicacion = DateTime.Parse("2020/08/29 12:14:01"), Precio = new Precio { PrecioNormal = 400000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 5", Descripcion = "Descripción del curso de prueba 5", FechaPublicacion = DateTime.Parse("2020/08/29 12:15:01"), Precio = new Precio { PrecioNormal = 500000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 6", Descripcion = "Descripción del curso de prueba 6", FechaPublicacion = DateTime.Parse("2020/08/29 12:16:01"), Precio = new Precio { PrecioNormal = 600000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 7", Descripcion = "Descripción del curso de prueba 7", FechaPublicacion = DateTime.Parse("2020/08/29 12:17:01"), Precio = new Precio { PrecioNormal = 700000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 8", Descripcion = "Descripción del curso de prueba 8", FechaPublicacion = DateTime.Parse("2020/08/29 12:18:01"), Precio = new Precio { PrecioNormal = 800000, PrecioPromocion = 40000 } },
                    new Curso { Titulo = "Título del curso de prueba 9", Descripcion = "Descripción del curso de prueba 9", FechaPublicacion = DateTime.Parse("2020/08/29 12:19:01"), Precio = new Precio { PrecioNormal = 900000, PrecioPromocion = 40000 } }
                };

                context.Curso.AddRange(listaCurso);
                await context.SaveChangesAsync();
            }

            if (!context.Instructor.Any())
            {

                var listaInstructor = new List<Instructor>() {
                    new Instructor { NombreCompleto = "Araceli Vasquez", Profesion = "Actor", Cargo = "Gerente" },
                    new Instructor { NombreCompleto = "Serafina Rosell", Profesion = "Electricista", Cargo = "Director" },
                    new Instructor { NombreCompleto = "Leonardo Ferrando", Profesion = "Arquitecto", Cargo = "Diseñador" },
                    new Instructor { NombreCompleto = "Jaime Benavides", Profesion = "Empresario", Cargo = "Lider" },
                    new Instructor { NombreCompleto = "Ramon Montaño", Profesion = "Abogado", Cargo = "Consultor" }
                };

                context.Instructor.AddRange(listaInstructor);
                await context.SaveChangesAsync();
            }


            if (!context.CursoInstructor.Any())
            {
                var listaCursoInstructor = new List<CursoInstructor>() {
                    new CursoInstructor { Curso = context.Curso.Where(c => c.Titulo.EndsWith("1")).FirstOrDefault(), Instructor = context.Instructor.Where(c => c.Profesion == "Actor").FirstOrDefault()  },
                    new CursoInstructor { Curso = context.Curso.Where(c => c.Titulo.EndsWith("3")).FirstOrDefault(), Instructor = context.Instructor.Where(c => c.Profesion == "Arquitecto").FirstOrDefault()  },
                    new CursoInstructor { Curso = context.Curso.Where(c => c.Titulo.EndsWith("6")).FirstOrDefault(), Instructor = context.Instructor.Where(c => c.Profesion == "Abogado").FirstOrDefault()  }
                };

                context.CursoInstructor.AddRange(listaCursoInstructor);
                await context.SaveChangesAsync();
            }


        }

    }
}
