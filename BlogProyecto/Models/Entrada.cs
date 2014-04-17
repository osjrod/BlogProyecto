using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogProyecto.Models
{
    [Table("Entrada")]
    public class Entrada
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual IEnumerable<UserProfile> Usuario { get; set; }
        public String Titulo { get; set; }
        public String Contenido { get; set; }
        public bool Activo { get; set; }
    }
}