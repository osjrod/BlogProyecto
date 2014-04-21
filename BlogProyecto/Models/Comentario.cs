using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogProyecto.Models
{
 
    public class Comentario
    {
        public int Id { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Fecha { get; set; }
        public String Contenido { get; set; }
        public bool Activo { get; set; }
        public String Usuario { get; set; }
        public int EntradaId { get; set; }

 
    }
}