using Projeto_Vendedores.Interfaces;
using Projeto_Vendedores.Data;
using Projeto_Vendedores.Models;
using Microsoft.EntityFrameworkCore;
using Projeto_Vendedores.Services.Exceptions;
using Projeto_Vendedores.Migrations;

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

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(s => s.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(s => s.Date <= maxDate.Value);
            }
            return await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<SalesRecord> FindByIdAsync(int id)
        {
            return await _context.SalesRecord.Include(sr => sr.Seller).
                FirstOrDefaultAsync(sr => sr.Id == id);
        }
        public async Task<DateTime> FindFirstSaleAsync()
        {
            var first = _context.SalesRecord.OrderBy(f => f.Date).Select(f => f.Date).FirstAsync();
            return await first;
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
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
        public async Task UptadeAsync(SalesRecord obj)
        {
            if (!await _context.SalesRecord.AnyAsync(s => s.Id == obj.Id))
                throw new NotFoundException("Id not found");
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
