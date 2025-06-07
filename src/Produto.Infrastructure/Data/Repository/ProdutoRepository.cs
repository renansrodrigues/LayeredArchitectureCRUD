using Produto.Infrastructure.Data.Repository.Interface;

namespace Produto.Infrastructure.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }


        public async Task<Domain.Entities.Produto> Create(Domain.Entities.Produto produto)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<Domain.Entities.Produto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Produto> GetAll(Guid IdProduto)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Produto> Update(Domain.Entities.Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
