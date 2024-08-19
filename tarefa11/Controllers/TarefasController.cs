using ApiTarefas2.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace tarefa11.Controllers
{
    [Route("Tarefa")]
    [ApiController]
  
        public class TarefaController : ControllerBase
        {
            List<Tarefa> listatarefa = new List<Tarefa>();

            public TarefaController()
            {
                var tarefa1 = new Tarefa()
                {
                    Id = 1,
                    Descricao = "Estudo do API 1 parte",
                };
                var tarefa2 = new Tarefa()
                {
                    Id = 2,
                    Descricao = "Estudo do API 2 parte",
                };
                var tarefa3 = new Tarefa()
                {
                    Id = 3,
                    Descricao = "Estudo do API 3 parte",
                };
                listatarefa.Add(tarefa1);
                listatarefa.Add(tarefa2);
                listatarefa.Add(tarefa3);
            }

            [HttpGet]

            public IActionResult Get()
            {
                return Ok(listatarefa);
            }
            [HttpGet("{id}")]

            public IActionResult Get(int id)
            {
                var tarefa = listatarefa.Where(item => item.Id == id).FirstOrDefault();
                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }

            [HttpPost("{id}")]

            public IActionResult Post([FromBody] TarefaDTO item)
            {

                var contador = listatarefa.Count();
                var tarefa = new Tarefa();
                tarefa.Id = contador + 1;
                tarefa.Descricao = item.Descricao;
                tarefa.Feito = item.Feito;
                listatarefa.Add(tarefa);

                return StatusCode(StatusCodes.Status201Created, tarefa);
            }
            [HttpPut("{id}")]

            public IActionResult Put(int id, [FromBody] TarefaDTO item)
            {
                var tarefa = listatarefa.Where(item => item.Id == id).FirstOrDefault();

                if (tarefa == null)
                {
                    return NotFound();
                }
                tarefa.Descricao = item.Descricao;
                tarefa.Feito = item.Feito;

                return Ok(listatarefa);
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var tarefa = listatarefa.Where(item => item.Id == id).FirstOrDefault();

                if (tarefa == null)
                {
                    return NotFound();
                }
                listatarefa.Remove(tarefa);
                return Ok(tarefa);
            }
        }
    
   
}

