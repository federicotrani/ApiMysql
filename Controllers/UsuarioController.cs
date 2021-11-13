using ApiMysql.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMysql.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login([FromQuery]string email,[FromQuery] string password){

            DataContext db = new DataContext();

            Usuarios usuario = db.Usuarios.Where(x=>x.Email==email && x.Password==password && x.Activo==1).FirstOrDefault();

            if(usuario==null){
                return NotFound();
            }

            Guid token = Guid.NewGuid();

            try{
                usuario.Token=token.ToString();
                db.Usuarios.Update(usuario);
                db.SaveChanges();
            }catch(System.Exception){
                return BadRequest();
            }

            return Ok(token);
        }
    }
}