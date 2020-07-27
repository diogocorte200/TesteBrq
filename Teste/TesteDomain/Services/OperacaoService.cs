using System;
using System.Collections.Generic;
using TesteDomain.Entities;
using TesteDomain.Interfaces.Repositories;
using TesteDomain.Interfaces.Services;

namespace TesteDomain.Services
{
    public class OperacaoService : ServiceBase<Operacoes>, IOperacaoServices
    {
        private readonly IOperacoesRepository _operacoesRepository;

        public OperacaoService(IOperacoesRepository operacoesRepository)
            : base(operacoesRepository)
        {
            _operacoesRepository = operacoesRepository;

        }
    }
}
