using Produto.Application.Dtos;

namespace Produto.Application.Interface
{
    public interface IProdutoAppService
    {

         Task<ProdutoDto> Create(CreateProdutoDto produto);
        Task<ProdutoDto> Update(UpdateProdutoDto produtoUpdate);
        Task<ProdutoDto> Delete(Guid idproduto);
        Task<ProdutoDto> Get(Guid idproduto);


    }
}
