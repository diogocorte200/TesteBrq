using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApplication.Interface;
using TesteApplication.Model;
using TesteDomain.Entities;
using TesteDomain.Interfaces.Services;

namespace TesteApplication
{
    public class OperacaoAppService : AppServiceBase<Operacoes>, IOperacaoAppService
    {
        private readonly IOperacaoServices _operacaoServices;
        public OperacaoAppService(IOperacaoServices operacaoServices)
        : base(operacaoServices)
        {
            _operacaoServices = operacaoServices;
        }
        public List<TraderResponse> IndentificarCategoriaTrader(List<Trader> trader)
        {
            return Regra(trader);

        }

        private List<TraderResponse> Regra(List<Trader> trader)
        {
            if (trader != null)
            {
                var lista = new TraderResponse();
                var result = new List<TraderResponse>();

                if (trader != null)
                {
                    foreach (var item in trader)
                    {
                        if (item.ClientSector == "Público" && item.Valor < 1000000)
                        {
                            lista.ClientSector = "LOWRISK";
                        }
                        if (item.ClientSector == "Público" && item.Valor > 1000000)
                        {
                            lista.ClientSector = "MEDIUMRISK";
                        }
                        if (item.ClientSector == "Privado" && item.Valor > 1000000)
                        {
                            lista.ClientSector = "HIGHRISK";
                        }
                        result.Add(new TraderResponse
                        {
                            ClientSector = lista.ClientSector
                        });
                    }
                }
                return result;
            }
            else
            {
                return new List<TraderResponse>();
            }

        }
    }
}
