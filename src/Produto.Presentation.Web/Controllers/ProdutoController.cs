using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Dtos;
using Produto.Application.Interface;
using Produto.Presentation.Web.Middleware;
using System.ComponentModel;

namespace Produto.Presentation.Web.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService; 
        }


        
        [HttpPost("api/CreateProduto")]
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
                                  
            return Created();
        }

        [HttpGet("api/GetProduto")]
        public async Task<IActionResult> GetProduto(Guid Id)
        {
            ProdutoDto produtoDto = null;

            try
            {
                produtoDto = await _produtoAppService.Get(Id);

                if (produtoDto == null)
                {
                    return BadRequest("Nothing has been founded with this Id.");

                }

                if (!produtoDto.validationResult.IsValid)
                {

                    return BadRequest(produtoDto.validationResult.Errors);
                }
               

            }            
            catch (Exception ex)
            {
                BadRequest("Error during operation, please try again later.");
            }

            return Ok(produtoDto);
        }

        [HttpDelete("api/DeleteProduto")]
        public async Task<IActionResult> DeleteProduto(Guid Id)
        {
            ProdutoDto produtoDto = null;

            try
            {
                produtoDto = await _produtoAppService.Delete(Id);

                if (produtoDto == null)
                {
                    return BadRequest("Nothing has been founded with this Id.");

                }

                if (!produtoDto.validationResult.IsValid)
                {

                    return BadRequest(produtoDto.validationResult.Errors);
                }


            }
            catch (Exception ex)
            {
                BadRequest("Error during operation, please try again later.");
            }

            return Ok(produtoDto);
        }


        [HttpPut("api/UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(UpdateProdutoDto updateProdutoDto)
        {
            ProdutoDto produtoDto = null;

            try
            {
                produtoDto = await _produtoAppService.Update(updateProdutoDto);

                if (produtoDto == null)
                {
                    return BadRequest("Nothing has been founded with this Id.");

                }

                if (!produtoDto.validationResult.IsValid)
                {

                    return BadRequest(produtoDto.validationResult.Errors);
                }


            }
            catch (Exception ex)
            {
                BadRequest("Error during operation, please try again later.");
            }

            return Ok(produtoDto);
        }



    }
}
