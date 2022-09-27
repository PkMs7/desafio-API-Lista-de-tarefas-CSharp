using Microsoft.AspNetCore.Mvc;
using desafio_API_Lista_de_tarefas_CSharp.src.Context;
using desafio_API_Lista_de_tarefas_CSharp.src.Models;

namespace desafio_API_Lista_de_tarefas_CSharp.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ListaContext _context;

        public TarefaController(ListaContext context){

            _context = context;

        }

        [HttpPost()]
        public IActionResult AdicionarTarefa(Tarefa tarefa){

            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);

        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){

            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null){
                return NotFound();
            }

            return Ok(tarefa);

        }

        [HttpGet("ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo){

            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            return Ok(tarefa);
        }

        [HttpGet("ObterPorData/{data}")]
        public IActionResult ObterPorData(DateTime data){

            var tarefa = _context.Tarefas.Where(x => x.Data.Equals(data));
            
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus/{status}")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status){

            var tarefa = _context.Tarefas.Where(x => x.Status.Equals(status));
            return Ok(tarefa);

        }
                
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos(){

            var tarefas = _context.Tarefas;

            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa){

            var tarefaBanco = _context.Tarefas.Find(id);
            
            if (tarefaBanco == null){

                return NotFound();

            }

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();


            return Ok(tarefaBanco);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){

            var tarefaBanco = _context.Tarefas.Find(id);
            
            if (tarefaBanco == null){

                return NotFound();

            }

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();


            return Ok(tarefaBanco);

        }
    }
}