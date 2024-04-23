using System.ComponentModel.DataAnnotations;

namespace Projeto_Vendedores.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSeller(Seller sl)
        {
            Sellers.Add(sl);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(p => p.TotalSales(initial, final));
        }

    }
}
