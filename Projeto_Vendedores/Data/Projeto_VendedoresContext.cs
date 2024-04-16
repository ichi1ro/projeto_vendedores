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

        public DbSet<Projeto_Vendedores.Models.Department> Department { get; set; } = default!;
    }
}
