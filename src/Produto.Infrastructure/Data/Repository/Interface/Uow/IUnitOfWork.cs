namespace Produto.Infrastructure.Data.Repository.Interface.Uow
{
    public interface IUnitOfWork : IDisposable
    {
       IProdutoRepository Produtos { get; }
        Task<int> CompletedAsync(); // Salva as alterações
        void Dispose();
    }
}
