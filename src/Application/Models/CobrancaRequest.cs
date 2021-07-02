using System;

namespace Cobrancas.Application.Models
{
    public class CobrancaRequest
    {
        public string Id { get; set; }

        public string CPF { get; set; }

        public DateTime vencimento { get; set; }

        public float valor { get; set; }
    }
}