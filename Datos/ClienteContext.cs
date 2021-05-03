using Microsoft.EntityFrameworkCore;
using Modelos;
using System;

namespace Datos
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base() { }
        public ClienteContext(string cn) : base(GetOptions(cn)) { }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
