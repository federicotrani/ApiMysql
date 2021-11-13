using ApiMysql.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMysql.Controllers
{
    public class TokenController : Controller
    {
        public bool ValidarToken([FromQuery] string token){

            bool resultado = false;

            DataContext db = new DataContext();

            Usuarios usuario = null;
            
            try{
                usuario = db.Usuarios.Where(x=>x.Token==token && x.Activo==1).FirstOrDefault();
            }catch(System.Exception ex){
                return resultado;
            }

            if(usuario==null){
                return resultado;
            }else{
                resultado = true;
            }

            return resultado;
        }

        public bool ValidarAuthorization(){

            string token = Request.Headers["Authorization"];

            bool resultado = false;

            DataContext db = new DataContext();

            Usuarios usuario = null;
            
            try{
                usuario = db.Usuarios.Where(x=>x.Token==token && x.Activo==1).FirstOrDefault();
            }catch(System.Exception ex){
                return resultado;
            }

            if(usuario==null){
                return resultado;
            }else{
                resultado = true;
            }

            return resultado;
        }
    }
}

