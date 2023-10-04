using Microsoft.EntityFrameworkCore;

namespace DesafioSiemensEnergy.Models
{
    public class ContextoClientes : DbContext
    {
        public ContextoClientes(DbContextOptions<ContextoClientes> options) : base(options)
        {

        }

        public DbSet<Cidade> Cidade { get; set; }
    }
}