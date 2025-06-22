using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Produto.Infrastructure.Data;
using Produto.Infrastructure.Data.Repository;

namespace Produto.Infrastructure.Tests.Infra
{

    public class ProdutoRepositoryTest
    {



        private DbContextOptions<ProdutoContext> CreateNewContextOptions()
        {
            // Use um nome de banco de dados único para cada teste para garantir isolamento
            var options = new DbContextOptionsBuilder<ProdutoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return options;
        }
        [Fact]
        public async Task Create_Produto_with_valid_Id()
        {


            var options = CreateNewContextOptions();

            using (var context = new ProdutoContext(options))
            {

                // Garante que o banco de dados em memória esteja limpo e criado
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var produtoRepo = new ProdutoRepository(context);


                Domain.Entities.Produto produto = new Domain.Entities.Produto();
                produto.Price = 100;
                produto.Description = "Description";
                produto.Name = "Name";  

                var result  = await produtoRepo.Create(produto);

                result.Should().NotBeNull();
                result.Name.Should().Be("Name");
                result.Description.Should().Be("Description");
                result.Price.Should().Be(100);


                // Opcional: Verifique se o produto realmente foi adicionado ao banco de dados (em memória)
                var productInDb = await context.Produtos.FindAsync(result.Id);
                productInDb.Should().NotBeNull();
                productInDb.Name.Should().Be("Name");
                productInDb.Price.Should().Be(100);




            }

        }


        [Fact]
        public async Task Update_Produto_with_valid_Id()
        {
            var options = CreateNewContextOptions();

            using (var context = new ProdutoContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var produtoRepo = new ProdutoRepository(context);

                Domain.Entities.Produto produto = new Domain.Entities.Produto();
                produto.Price = 100;
                produto.Description = "Description";
                produto.Name = "Name";
                produto.Id = new Guid("11a2aefa-d2f7-49d5-9ad2-25b81731c59b");
                

                var result =  produtoRepo.Update(produto);
                var productInDb = await context.Produtos.FindAsync(result.Id);

                result.Id.Should().Be(produto.Id);
                result.Should().NotBeNull();
                result.Id.Should<Guid>();
                                

            }


        }


        [Fact]
        public async Task Delete_Produto_with_valid_Id()
        {
            var options = CreateNewContextOptions();

            using (var context = new ProdutoContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var produtoRepo = new ProdutoRepository(context);
                
                Domain.Entities.Produto produto = new Domain.Entities.Produto();
                produto.Price = 100;
                produto.Description = "Description";
                produto.Name = "Name";
                produto.Id = new Guid("11a2aefa-d2f7-49d5-9ad2-25b81731c59b");               

                var result = await produtoRepo.Delete(produto);
                

                result.Id.Should().Be(produto.Id);
                result.Should().NotBeNull();
                result.Id.Should<Guid>();


            }


        }



        [Fact]
        public async Task Get_Produto_with_valid_Id()
        {
            var options = CreateNewContextOptions();

            using (var context = new ProdutoContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var produtoRepo = new ProdutoRepository(context);

                Domain.Entities.Produto produto = new Domain.Entities.Produto();
                produto.Price = 100;
                produto.Description = "Description";
                produto.Name = "Name";
                produto.Id = new Guid("11a2aefa-d2f7-49d5-9ad2-25b81731c59b");

                var result = await produtoRepo.Create(produto);
                var productInDb = await produtoRepo.Get(result.Id);



                productInDb.Id.Should().Be(produto.Id);
                productInDb.Should().NotBeNull();
                productInDb.Id.Should<Guid>();
                productInDb.Name.Should().Be("Name");
                productInDb.Description.Should().Be("Description");
                productInDb.Price.Should().Be(100);


            }


        }


    }
}
