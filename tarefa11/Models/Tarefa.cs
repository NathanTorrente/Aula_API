using Microsoft.AspNetCore.Mvc;

namespace tarefa11.Controllers
{
    public class Tarefa
    {
        public int Id { get; set; } 
        public string Descricao { get; set; }
        public bool Feito { get; set;}

        public DateTime Data { get; set;} = DateTime.Now;
       
    }
    public class TarefaController : ControllerBase
    {
        List<Tarefa> listatarefa = new List<Tarefa>();
        

        public TarefaController()
        {
            var tarefa1 = new Tarefa()
            {
                Id = 1,
                Descricao = "Estudo de API part 1"
            };
            var tarefa2 = new Tarefa()
            {
                Id = 2,
                Descricao = "Estudo de API part 2"
            };
            var tarefa3 = new Tarefa()
            {
                Id = 3,
                Descricao = "Estudo de API part 3"
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
            if(tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Tarefa item)
        {
            var tarefa = new Tarefa();
            tarefa.Id = item.Id;
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;
            listatarefa.Add(tarefa);

            return StatusCode(StatusCodes.Status201Created, tarefa);
        }

    }
}
