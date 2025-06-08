using Microsoft.AspNetCore.Mvc;
using Produto.Application.Dtos;
using Produto.Application.Interface;
using Produto.Presentation.Web.Middleware;

namespace Produto.Presentation.Web.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService; 
        }


        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {
            var produto = await  _produtoAppService.Create(createProdutoDto);

            if (produto == null)
            {
                return BadRequest("Error during operation, please try again later");
            
            }

            if(!produto.validationResult.IsValid)
            {

                return BadRequest(produto.validationResult.Errors);

            }
                                  
            return Ok(produto);
        }
    }
}
