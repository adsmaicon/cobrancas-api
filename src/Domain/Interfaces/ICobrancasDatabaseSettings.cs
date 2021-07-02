namespace Cobrancas.Domain.Interfaces
{
    public interface ICobrancasDatabaseSettings
    {
        string CobrancasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}