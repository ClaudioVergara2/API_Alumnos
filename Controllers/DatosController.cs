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
                List<Alumno> Lista= new List<Alumno>();
                //Lista = bdContext.Alumnos.ToList();
                Lista = bdContext.Alumnos.Include(a => a.IdAsignaturaNavigation).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", respuesta = Lista });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ERROR", respuesta = ex.Message });
            }
        }
    }
}
