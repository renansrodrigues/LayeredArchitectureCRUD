using Microsoft.EntityFrameworkCore;

namespace Produto.Infrastructure.Data
{
    public class ProdutoContext : DbContext
    {
       public ProdutoContext(DbContextOptions<ProdutoContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Domain.Entities.Produto> Produtos { get; set; }

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //=> optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SuplyChain;Username=postgres;Password=1234");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Desabilita a convenção de cascata de exclusão por padrão.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict; // Ou .NoAction
            }

            modelBuilder.Entity<Domain.Entities.Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(u => u.Name)
                 .IsRequired()      // NOT NULL
                 .HasMaxLength(50); // VARCHAR(50)

                entity.Property(u => u.Description)
                 .IsRequired()      // NOT NULL
                 .HasMaxLength(100); // VARCHAR(50)

                entity.Property(u => u.Price)
                .HasPrecision(10,2) 
                .IsRequired();

                entity.HasKey(u => u.Id);


            });

           base.OnModelCreating(modelBuilder);
        }

    }
}
