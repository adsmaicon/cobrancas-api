using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cobrancas.Domain.Entities
{
    public class Cobranca : BaseEntity
    {
        [BsonElement("CPF")]
        public string CPF { get; set; }

        [BsonElement("vencimento")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Vencimento { get; set; }

        [BsonElement("valor")]
        public float Valor { get; set; }
    }
}