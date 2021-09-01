using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class DataContext : DbContext
    {

        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades das classes que vão virar tabelas no banco
        public DbSet<Produto> Produtos { get; set; }

    }
}