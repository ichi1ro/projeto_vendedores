using Projeto_Vendedores.Data;
using Projeto_Vendedores.Interfaces;
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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
