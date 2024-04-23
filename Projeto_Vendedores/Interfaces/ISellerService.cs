using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Interfaces
{
    public interface ISellerService
    {
        Task<List<Seller>> FindAllAsync();
        Task InsertAsync(Seller obj);
        Task<Seller> FindByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UptadeAsync(Seller seller);
    }
}
