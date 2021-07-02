using System;

namespace Cobrancas.Application.Models
{
    public class CreateCobrancaRequest
    {
        public string CPF { get; set; }

        public DateTime vencimento { get; set; }

        public float valor { get; set; }
    }
}