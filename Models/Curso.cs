using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Models
{
    public class Curso
    {
        public int Id  { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Precio Precio { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<CursoInstructor> CursoInstructor { get; set; }

    }
}
