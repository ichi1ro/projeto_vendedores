using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Interfaces
{
    public interface ISellerService
    {
        List<Seller> FindAll();
        void Insert(Seller obj);
        Seller FindById(int id);
        void Remove(int id);
    }
}
