using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApi.ViewModels
{
    public class OperacoesViewModel
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string ClientSector { get; set; }
    }
}