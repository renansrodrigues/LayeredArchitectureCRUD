using Microsoft.AspNetCore.Mvc;
using Produto.Application.Dtos;
using Produto.Presentation.Web.Middleware;

namespace Produto.Presentation.Web.Controllers
{
    public class ProdutoController : Controller
    {        
        public ProdutoController()
        {
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {

          
                                  
            return View();
        }
    }
}
