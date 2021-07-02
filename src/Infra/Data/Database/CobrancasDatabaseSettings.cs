using Cobrancas.Domain.Interfaces;

namespace Cobrancas.Infra.Data.Database
{
    public class CobrancasDatabaseSettings : ICobrancasDatabaseSettings
    {
        public string CobrancasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}