using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Projeto_Vendedores.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }

        [ValidateNever]
        public ICollection<Department> Departments { get; set; }
    }
}
