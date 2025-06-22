using Produto.Application.Dtos;
using Produto.Application.Interface;
using Produto.Application.Validation;
using Produto.Infrastructure.Data.Repository.Interface;
using Produto.Infrastructure.Data.Repository.Interface.Uow;

namespace Produto.Application.AppServices
{
    public  class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoAppService(IProdutoRepository produtorepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtorepository;
            _unitOfWork = unitOfWork;   
        }


        public async Task<ProdutoDto> Create(CreateProdutoDto produtoDto)
        {
            ProdutoValidation validation = new ProdutoValidation();
            ProdutoDto retorno = new ProdutoDto();
            var ProdutoModel = produtoDto.DtoCreateToDomain(produtoDto);
            validation.ProdutoCreateValidation();
            ProdutoModel.validationResult = validation.Validate(ProdutoModel);
           
            if (ProdutoModel.validationResult.IsValid)
            {
                retorno = produtoDto.DomainToDto(await _unitOfWork.Produtos.Create(ProdutoModel));
              await  _unitOfWork.CompletedAsync();
            }
            
            retorno.validationResult = ProdutoModel.validationResult;
            return retorno;
        }


        public async Task<ProdutoDto> Get(Guid idproduto)
        {
            ProdutoValidation validation = new ProdutoValidation();
            ProdutoDto retorno = new ProdutoDto();
            retorno.Id = idproduto;

            var ProdutoModel = retorno.DtoToDomain(retorno);

            validation.ProdutoGetValidation();
            ProdutoModel.validationResult = validation.Validate(ProdutoModel);

            if (ProdutoModel.validationResult.IsValid)
            {
                retorno = retorno.DomainToDto(await _unitOfWork.Produtos.Get(idproduto));

            }

            retorno.validationResult = ProdutoModel.validationResult;

            return retorno;

        }



        public async Task<ProdutoDto> Delete(Guid idproduto)
        {
            ProdutoValidation validation = new ProdutoValidation();
            ProdutoDto retorno = new ProdutoDto();
            retorno.Id = idproduto;

            var ProdutoModel = retorno.DtoToDomain(retorno);

            validation.ProdutoGetValidation();
            ProdutoModel.validationResult = validation.Validate(ProdutoModel);

            if (ProdutoModel.validationResult.IsValid)
            {
                retorno = retorno.DomainToDto(await _unitOfWork.Produtos.Delete(ProdutoModel));

            }

            retorno.validationResult = ProdutoModel.validationResult;

            return retorno;



        }


        public async Task<ProdutoDto> Update(UpdateProdutoDto produtoUpdateDto)
        {
            ProdutoValidation validation = new ProdutoValidation();
            ProdutoDto retorno = new ProdutoDto();
            var ProdutoModel = produtoUpdateDto.DtoUpdateToDomain(produtoUpdateDto);
            validation.ProdutoUpdateValidation();
            ProdutoModel.validationResult = validation.Validate(ProdutoModel);

            if (ProdutoModel.validationResult.IsValid)
            {
                retorno = produtoUpdateDto.DomainToDto(_unitOfWork.Produtos.Update(ProdutoModel));
                await _unitOfWork.CompletedAsync();
            }

            retorno.validationResult = ProdutoModel.validationResult;
            return retorno;

        }

      


    }
}
