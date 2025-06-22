namespace Produto.Infrastructure.Data.Repository.Interface
{
    public interface IProdutoRepository
    {
         Task<Domain.Entities.Produto> Create(Domain.Entities.Produto produto);
         Domain.Entities.Produto Update(Domain.Entities.Produto produto);        
         Task<Domain.Entities.Produto> Get(Guid IdProduto);
        Task<Domain.Entities.Produto> Delete(Domain.Entities.Produto produto);
    }
}
