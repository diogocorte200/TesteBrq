using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApplication.Model;
using TesteDomain.Entities;

namespace TesteApplication.Interface
{
    public interface IOperacaoAppService : IAppServiceBase<Operacoes>
    {
        List<TraderResponse> IndentificarCategoriaTrader(List<Trader> trader);
    }
}
