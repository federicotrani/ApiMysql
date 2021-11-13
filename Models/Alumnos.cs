using System;
using System.Collections.Generic;

namespace ApiMysql.Models
{
    public partial class Alumnos
    {
        public int IdAlumnos { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }
        public int Activo { get; set; }
        public int Favoritos { get; set; }
    }
}
