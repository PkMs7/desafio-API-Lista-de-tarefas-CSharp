using desafio_API_Lista_de_tarefas_CSharp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_API_Lista_de_tarefas_CSharp.src.Context
{
    public class ListaContext : DbContext
    {
        public ListaContext(DbContextOptions<ListaContext> options) : base(options){

        }

        public DbSet<Tarefa> Tarefas { get; set; }
        
    }
}