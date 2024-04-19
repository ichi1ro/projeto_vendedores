using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Interfaces
{
    public interface ISellerService
    {
        List<Seller> FindAll();
        void Insert(Seller obj);
    }
}
