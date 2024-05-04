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

        Task <List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate);
        Task<DateTime> FindFirstSaleAsync();
        List<SalesRecord> FindBySeller(int? id, List<SalesRecord> list);
        List<SalesRecord> FindByStatus(int? status, List<SalesRecord> list);

        List<SalesRecord> FindByAmount(double? minAmount, double? maxAmount, List<SalesRecord> list);

        Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate);

    }
}
