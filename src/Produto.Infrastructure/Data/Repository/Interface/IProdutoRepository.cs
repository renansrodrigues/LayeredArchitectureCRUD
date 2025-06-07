namespace Produto.Infrastructure.Data.Repository.Interface
{
    public interface IProdutoRepository
    {
        public Task<Domain.Entities.Produto> Create(Domain.Entities.Produto produto);
        public Task<Domain.Entities.Produto> Update(Domain.Entities.Produto produto);
        public Task<IEnumerable<Domain.Entities.Produto>> GetAll();
        public Task<Domain.Entities.Produto> GetAll(Guid IdProduto);
    }
}
