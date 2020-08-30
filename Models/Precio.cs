using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Models
{
    public class Precio
    {
        public int Id { get; set; }
        public decimal PrecioNormal { get; set; }
        public decimal PrecioPromocion { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
