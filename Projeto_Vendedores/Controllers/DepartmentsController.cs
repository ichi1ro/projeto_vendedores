using Microsoft.AspNetCore.Mvc;
using Projeto_Vendedores.Models;
namespace Projeto_Vendedores.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> Departments = new List<Department>();
            Departments.Add(new Department() { Id = 1, Name = "Eletronics" });
            Departments.Add(new Department() { Id = 2, Name = "Fashion" });
            return View(Departments); //envia para a view os dados do controller
        }
    }
}
