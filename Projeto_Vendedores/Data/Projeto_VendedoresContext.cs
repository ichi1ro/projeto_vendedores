using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Vendedores.Models;

namespace Projeto_Vendedores.Data
{
    public class Projeto_VendedoresContext : DbContext
    {
        public Projeto_VendedoresContext (DbContextOptions<Projeto_VendedoresContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
        //This would be the null forgiving operator (!).
        //It tells the compiler "this isn't null, trust me", so it does not issue a warning for a possible null reference.


    }
}
