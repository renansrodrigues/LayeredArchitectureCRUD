using Microsoft.EntityFrameworkCore;

namespace Produto.Infrastructure.Data
{
    public class ProdutoContext : DbContext
    {
       public ProdutoContext(DbContextOptions<ProdutoContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Domain.Entities.Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql("<connection string>");


    }
}
