using FluentValidation;

namespace Produto.Application.Validation
{
    public class ProdutoValidation : AbstractValidator<Domain.Entities.Produto>
    {
    
    
        public void ProdutoCreateValidation() 
        {
          RuleFor(x=>x.Name).NotEmpty().WithMessage("Product Name is mandatory.");
          RuleFor(x => x.Description).NotEmpty().WithMessage("Product Description is mandatory.");
          RuleFor(x => x.Price).GreaterThan(0).WithMessage("Product Price must be greaten than 0.");

        }



        public void ProdutoUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is mandatory.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is mandatory.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Product Description is mandatory.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Product Price must be greaten than 0.");
        }


        public void ProdutoGetValidation()
        {            
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not been empt")
           .Must(id => Guid.TryParse(id.ToString(), out _))
           .WithMessage("The Id must be a valid GUID.");
        }


        public void ProdutoDeleteValidation()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not been empt")
           .Must(id => Guid.TryParse(id.ToString(), out _))
           .WithMessage("The Id must be a valid GUID.");
        }

    }
}