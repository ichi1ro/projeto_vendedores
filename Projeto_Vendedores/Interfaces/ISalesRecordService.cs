using Projeto_Vendedores.Models;
namespace Projeto_Vendedores.Interfaces
{
    public interface ISalesRecordService
    {
        Task<List<SalesRecord>> FindAllAsync();
        Task InsertAsync(SalesRecord obj);
        Task<SalesRecord> FindByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UptadeAsync(SalesRecord seller);
    }
}
