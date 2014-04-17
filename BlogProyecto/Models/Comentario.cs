using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogProyecto.Models
{
 [Table("Comentario")]
    public class Comentario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual IEnumerable<Entrada> Entrada { get; set; }
        public String Contenido { get; set; }
        public String Activo { get; set; }
    }
}