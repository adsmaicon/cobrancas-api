using System;

namespace Cobrancas.Application.Models
{
    public class CobrancaResponse
    {
        public string Id { get; set; }

        public string CPF { get; set; }

        public DateTime vencimento { get; set; }

        public float valor { get; set; }
    }
}