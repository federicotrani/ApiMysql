using System.Collections.Generic;
using System.Linq;
using ApiMysql.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMysql.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlumnoController : TokenController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public IActionResult ListarTodos(){

            List<Alumnos> lista = db.Alumnos.ToList();

            if(lista.Count==0){
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpGet]
        public IActionResult ListarActivos([FromQuery]string token){

            // verificamos token valido de cliente
            if(!this.ValidarAuthorization()){
                return BadRequest();
            }

            List<Alumnos> lista = db.Alumnos.Where(p=>p.Activo==1).ToList();

            if(lista.Count==0){
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpGet]
        public IActionResult ListarFavoritos(){

            // verificamos token valido de cliente
            if(!this.ValidarAuthorization()){
                return BadRequest();
            }

            List<Alumnos> lista = db.Alumnos.Where(p=>p.Activo==1 && p.Favoritos==1).ToList();

            if(lista.Count==0){
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId([FromRoute]int id){
            Alumnos alumno = new Alumnos();

            alumno = db.Alumnos.Find(id);

            if(alumno==null){
                return NotFound();
            }

            return Ok(alumno);
        }

        [HttpPost]
        public IActionResult Agregar([FromBody]Alumnos alumno){

            try{
                db.Alumnos.Add(alumno);
                db.SaveChanges();
                return Ok();

            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Editar([FromBody] Alumnos alumno){


            try{
                db.Update(alumno);
                
                db.SaveChanges();

            }catch(System.Exception ex){
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Desactivar([FromRoute]int id){

            Alumnos alumno = db.Alumnos.Find(id);

            try{
                alumno.Activo=0;
                db.Update(alumno);
                db.SaveChanges();

            }catch(System.Exception ex){
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Activar([FromRoute]int id){

            Alumnos alumno = db.Alumnos.Find(id);

            try{
                alumno.Activo=1;
                db.Update(alumno);
                db.SaveChanges();

            }catch(System.Exception ex){
                return BadRequest();
            }

            return Ok();
        }
    }
}