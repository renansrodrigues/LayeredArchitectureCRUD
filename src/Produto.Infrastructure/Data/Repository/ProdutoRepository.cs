using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Domain.Entities.Produto> Get(Guid IdProduto)
        {
             return await (_context.Set<Domain.Entities.Produto>().FindAsync(IdProduto)); 
        }

        public  Domain.Entities.Produto Update(Domain.Entities.Produto produto)
        {
             _context.Set<Domain.Entities.Produto>().Update(produto);
             _context.SaveChanges();
            return produto;
        }

       public  async Task<Domain.Entities.Produto> Delete(Domain.Entities.Produto produto)
       {           
           var remoprod =  _context.Set<Domain.Entities.Produto>().Remove(produto);            
           await _context.SaveChangesAsync();
            
           return remoprod.Entity;

        }
    }
}
