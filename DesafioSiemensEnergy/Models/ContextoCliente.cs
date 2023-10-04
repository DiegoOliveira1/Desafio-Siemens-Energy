using Microsoft.EntityFrameworkCore;
using DesafioSiemensEnergy.Models;

namespace DesafioSiemensEnergy.Models
{
    public class ContextoCidades : DbContext
    {
        public ContextoCidades(DbContextOptions<ContextoCidades> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<DesafioSiemensEnergy.Models.Cidade> Cidade { get; set; } = default!;
    }
}

