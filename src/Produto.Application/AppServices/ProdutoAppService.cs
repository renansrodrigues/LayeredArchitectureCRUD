using Produto.Application.Dtos;
using Produto.Infrastructure.Data.Repository.Interface.Uow;

namespace Produto.Application.AppServices
{
    public  class ProdutoAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }


        public  async Task<ProdutoDto> Create(ProdutoDto produtoDto)
        {


            _unitOfWork.Produtos.Create()
            //Todo: validar inserts

        }

        public async Task<ProdutoDto> Update(UpdateProdutoDto produtoDto)
        {
            //Todo: validar update





        }


        public async Task<IEnumerable<ProdutoDto>> GetAll()
        {
            

        }



        public async Task<ProdutoDto> GetAll(Guid idproduto)
        {
            

        }

    }
}
