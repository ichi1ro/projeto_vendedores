using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Projeto_Vendedores.Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace Projeto_Vendedores.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(100.0, 70000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public SaleStatus Status { get; set; }
        [Required(ErrorMessage = "{0} required")]

        [ValidateNever]
        public Seller Seller { get; set; }

        [Required(ErrorMessage="{0} required")]
        public int SellerId { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(DateTime dtNow)
        {
            Date = dtNow;
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
