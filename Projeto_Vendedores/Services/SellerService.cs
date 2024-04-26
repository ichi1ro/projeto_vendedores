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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync(); 
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UptadeAsync(Seller seller)
        {
            if (!await _context.Seller.AnyAsync(s => s.Id == seller.Id)) 
                throw new NotFoundException("Id not found");
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }  
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
