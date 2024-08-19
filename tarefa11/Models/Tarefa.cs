using Microsoft.AspNetCore.Mvc;

namespace tarefa11.Controllers
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Feito { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

    }
}
