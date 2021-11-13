using System;
using System.Collections.Generic;

namespace ApiMysql.Models
{
    public partial class Usuarios
    {
        public int IdUsuarios { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public int Activo { get; set; }
    }
}
