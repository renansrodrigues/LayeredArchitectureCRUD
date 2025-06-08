using Produto.Infrastructure.Data.Repository.Interface;
using Produto.Infrastructure.Data.Repository.Interface.Uow;

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
             await _context.Set<Domain.Entities.Produto>().AddAsync(produto);
            return produto;
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
