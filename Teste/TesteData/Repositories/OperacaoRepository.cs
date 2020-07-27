using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDomain.Entities;
using TesteDomain.Interfaces.Repositories;

namespace TesteData.Repositories
{
    public class OperacaoRepository : RepositoryBase<Operacoes>, IOperacoesRepository
    {
    }
}
