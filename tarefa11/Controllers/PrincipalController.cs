using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tarefa11.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok("API Tarefas: online");
        }

        [HttpGet("Hello-World")]
        public IActionResult GetWelloWorld()
        {
            return Ok("Hello world do João");
        }
      
        [HttpGet("Autor")]
        public IActionResult GetAutor() 
        {
        return Ok("Feito por UsuárioAnonimo");
        }
    }
}
