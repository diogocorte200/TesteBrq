using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TesteApi.ViewModels;
using TesteApplication.Interface;
using TesteApplication.Model;
using TesteDomain.Entities;

namespace TesteApi.Controllers
{
    public class OperacoesController : ApiController
    {

        private readonly IOperacaoAppService _operacaoAppService;

        public OperacoesController(IOperacaoAppService operacaoAppService)
        {
            _operacaoAppService = operacaoAppService;

        }
        [AcceptVerbs("POST")]
        [Route("CalcularOperacoes")]
        public Task<HttpResponseMessage> CalcularOperacoes([FromBody] List<Trader> operacoesViewModel)
        {

            if (operacoesViewModel != null)
            {


                var lista = _operacaoAppService.IndentificarCategoriaTrader(operacoesViewModel);
                var retorno = lista.Select(item => new TraderResponse
                {
                    ClientSector = item.ClientSector,
                });

                HttpResponseMessage response = new HttpResponseMessage();
                response = Request.CreateResponse(HttpStatusCode.OK, retorno);
                var result = new TaskCompletionSource<HttpResponseMessage>();
                result.SetResult(response);
                return result.Task;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = Request.CreateResponse(HttpStatusCode.OK, "Erro");
                var result = new TaskCompletionSource<HttpResponseMessage>();
                result.SetResult(response);
                return result.Task;

            }
        }

    }
}
