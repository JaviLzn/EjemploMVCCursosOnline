using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Profesion { get; set; }
        public string Cargo { get; set; }
        public ICollection<CursoInstructor> CursoInstructor { get; set; }

    }
}
