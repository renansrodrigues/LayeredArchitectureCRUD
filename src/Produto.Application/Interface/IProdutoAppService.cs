using Produto.Application.Dtos;

namespace Produto.Application.Interface
{
    public interface IProdutoAppService
    {

        public Task<ProdutoDto> Create(CreateProdutoDto produto);
        //public Task<ProdutoDto> Update(UpdateProdutoDto produtoUpdate);
        //public Task<IEnumerable<ProdutoDto>> GetAll();
        //public Task<ProdutoDto> GetAll(Guid IdProduto);


    }
}
