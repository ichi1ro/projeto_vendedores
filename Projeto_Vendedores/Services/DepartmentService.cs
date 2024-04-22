using Microsoft.EntityFrameworkCore;
using Projeto_Vendedores.Data;
using Projeto_Vendedores.Interfaces;
using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Projeto_VendedoresContext _context;

        public DepartmentService(Projeto_VendedoresContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
        public Department FindById(int id)
        {
            return _context.Department.FirstOrDefault(s => s.Id == id);
        }
    }
}
