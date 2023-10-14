using _201012_API1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _201012_API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        public readonly ClasesContext bdContext;

        public DatosController(ClasesContext _contexto)
        {
            bdContext= _contexto;
        }
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            try
            {
                List<Alumno> lista = new List<Alumno>();
                //lista = bdContext.Alumnos.ToList();
                //lista = bdContext.Alumnos.Include(a => a.IdAsignaturaNavigation).ToList();
                lista = bdContext.Alumnos.FromSqlRaw("SELECT * FROM ALUMNO").ToList();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "OK",
                    respuesta = lista
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Alumno al)
        {
            try
            {
                Alumno insertar = new Alumno();
                insertar.NombreAlumno = al.NombreAlumno;
                insertar.Estado = al.Estado;
                insertar.IdAsignatura = al.IdAsignatura;

                bdContext.Add(insertar);
                bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = "Correcto"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Eliminar")]

        public IActionResult Eliminar(int ID)
        {
            try
            {
                Alumno? al = bdContext.Alumnos.Find(ID);
                bdContext.Alumnos.Remove(al);
                bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = "Correcto"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Editar")]

        public IActionResult Editar(int ID, string nombre, int estado, int asignatura)
        {
            try
            {
                Alumno? al = bdContext.Alumnos.Where(a => a.IdAlumno == ID).First();
                al.NombreAlumno = nombre;
                al.Estado = estado;
                al.IdAsignatura = asignatura;

                bdContext.Entry(al).State = EntityState.Modified;
                bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = "Correcto"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ERROR",
                    respuesta = ex.Message
                });
            }
        }
    }
}
