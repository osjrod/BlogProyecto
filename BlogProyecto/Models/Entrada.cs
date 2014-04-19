using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogProyecto.Models
{
    
    public class Entrada
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual UserProfile Usuario { get; set; }
        public String Titulo { get; set; }
        public String Contenido { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}