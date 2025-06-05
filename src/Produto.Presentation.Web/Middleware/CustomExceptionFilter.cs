using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Produto.Presentation.Web.Middleware
{
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;

            //Logar erro .

            context.Result = new ObjectResult(new
            {
                StattusCode = (int)HttpStatusCode.InternalServerError,
                MensagemErro = "Ocorreu erro no processamento, tente novamente."

            });

            context.ExceptionHandled = true;
            return;

        }
    }
}
