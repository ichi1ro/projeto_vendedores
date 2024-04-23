using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}
