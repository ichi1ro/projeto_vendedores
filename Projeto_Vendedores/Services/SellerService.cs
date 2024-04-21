using Microsoft.EntityFrameworkCore;
using Projeto_Vendedores.Data;
using Projeto_Vendedores.Interfaces;
using Projeto_Vendedores.Models;
using Projeto_Vendedores.Services.Exceptions;

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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Uptade(Seller seller)
        {
            if (!_context.Seller.Any(s => s.Id == seller.Id)) throw new NotFoundException("Id not found");
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }  
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
