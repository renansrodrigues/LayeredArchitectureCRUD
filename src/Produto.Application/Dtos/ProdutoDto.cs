

using FluentValidation.Results;

namespace Produto.Application.Dtos
{
    public class ProdutoDto : ProdutoDtoMaster
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public decimal Price { get; set; }

        public ValidationResult validationResult { get; set; } = new ValidationResult();

       

        public Domain.Entities.Produto DtoToDomain(ProdutoDto produtoDto)
        {
            return new Domain.Entities.Produto
            {
                Id = produtoDto.Id,
                Name = produtoDto.Name,
                Description = produtoDto.Description,
                Price = produtoDto.Price

            };

        }

    }

    public class CreateProdutoDto : ProdutoDtoMaster
    {
        public string Name { get; set; } = string.Empty;
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

       



    }


    public class UpdateProdutoDto :  ProdutoDtoMaster
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Domain.Entities.Produto DtoUpdateToDomain(UpdateProdutoDto updateProdutoDto)
        {
            return new Domain.Entities.Produto
            {
                Id = updateProdutoDto.Id,
                Name = updateProdutoDto.Name,
                Description = updateProdutoDto.Description,
                Price = updateProdutoDto.Price
            };


        }

    }

    public abstract class ProdutoDtoMaster
    {


        public ProdutoDto DomainToDto(Domain.Entities.Produto produtoDto)
        {

            if(produtoDto == null) { return null; }

            return new ProdutoDto
            {
                Id = produtoDto.Id,
                Name = produtoDto.Name,
                Description = produtoDto.Description,
                Price = produtoDto.Price

            };

        }

    }


}
