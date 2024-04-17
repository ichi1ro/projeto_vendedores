using Projeto_Vendedores.Data;
using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Services
{
    public class SellerService : ISellerService
    {
        private readonly Projeto_VendedoresContext _context;
        public SellerService(Projeto_VendedoresContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
