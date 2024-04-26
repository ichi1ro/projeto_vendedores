using Projeto_Vendedores.Interfaces;
using Projeto_Vendedores.Data;
using Projeto_Vendedores.Models;
using Microsoft.EntityFrameworkCore;
using Projeto_Vendedores.Services.Exceptions;

namespace Projeto_Vendedores.Services
{
    public class SalesRecordService : ISalesRecordService
    {
        private readonly Projeto_VendedoresContext _context;
        public SalesRecordService(Projeto_VendedoresContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindAllAsync()
        {
            return await _context.SalesRecord.ToListAsync();
        }

        public async Task<SalesRecord> FindByIdAsync(int id)
        {
            return await _context.SalesRecord.Include(sr => sr.Seller).
                FirstOrDefaultAsync(sr => sr.Id == id);
        }

        public async Task InsertAsync(SalesRecord obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.SalesRecord.FindAsync(id);
                _context.SalesRecord.Remove(obj);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UptadeAsync(SalesRecord obj)
        {
            if (!await _context.Seller.AnyAsync(s => s.Id == obj.Id))
                throw new NotFoundException("Id not found");
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
