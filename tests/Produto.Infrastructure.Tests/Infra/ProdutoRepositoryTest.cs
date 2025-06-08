using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Produto.Infrastructure.Data;
using Produto.Infrastructure.Data.Repository;
using Produto.Infrastructure.Data.Repository.Interface;
using Produto.Infrastructure.Data.Repository.Interface.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    
    
    
    }
}
