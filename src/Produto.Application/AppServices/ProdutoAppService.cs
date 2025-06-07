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

            ProdutoModel.validationResult = validation.Validate(ProdutoModel);
           
            if (ProdutoModel.validationResult.IsValid)
            {
                retorno = produtoDto.DomainCreateToDto(await _unitOfWork.Produtos.Create(ProdutoModel));
              await  _unitOfWork.CompletedAsync();
            }
            
            retorno.validationResult = ProdutoModel.validationResult;
            return retorno;
        }

     



        //public async Task<ProdutoDto> Update(UpdateProdutoDto produtoDto)
        //{
        //    //Todo: validar update

        //}


        //public async Task<IEnumerable<ProdutoDto>> GetAll()
        //{

        //}



        //public async Task<ProdutoDto> GetAll(Guid idproduto)
        //{

        //}


    }
}
