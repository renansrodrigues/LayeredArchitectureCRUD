

using FluentValidation.Results;

namespace Produto.Application.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public decimal Price { get; set; }

        public ValidationResult validationResult { get; set; } = new ValidationResult();

      
    }

    public class CreateProdutoDto
    {        
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Domain.Entities.Produto DtoCreateToDomain(CreateProdutoDto produtoDto)
        {
            return new Domain.Entities.Produto
            {
                Name = produtoDto.Name,
                Description = produtoDto.Description,
                Price = produtoDto.Price
            };


        }

        public ProdutoDto DomainCreateToDto(Domain.Entities.Produto produtoDto)
        {
            return new ProdutoDto
            {
                Id = produtoDto.Id,
                Name = produtoDto.Name,
                Description = produtoDto.Description,
                Price = produtoDto.Price

            };

        }

    }


    public class UpdateProdutoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }


}
