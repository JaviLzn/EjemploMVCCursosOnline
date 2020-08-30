using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string TextoComentario { get; set; }
        public string NombrePersona { get; set; }
        public decimal Puntaje { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
