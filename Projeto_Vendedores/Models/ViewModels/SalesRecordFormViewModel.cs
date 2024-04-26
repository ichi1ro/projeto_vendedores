using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Projeto_Vendedores.Models.ViewModels
{
    public class SalesRecordFormViewModel
    {
        public SalesRecord SalesRecord { get; set; }

        [ValidateNever]
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
