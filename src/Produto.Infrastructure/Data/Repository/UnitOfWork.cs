using Produto.Infrastructure.Data.Repository.Interface;
using Produto.Infrastructure.Data.Repository.Interface.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdutoContext _context;
        private IProdutoRepository _produtos;

        public UnitOfWork(ProdutoContext context)
        {
            _context = context;
        }

        public IProdutoRepository Produtos
        {
            get
            {

                return _produtos == null? new ProdutoRepository(_context): _produtos;

            }
        }

        

        public  Task<int> CompletedAsync()
        {

            return  _context.SaveChangesAsync();

        }

     

        public void Dispose()
        {
             _context.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
