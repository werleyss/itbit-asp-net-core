using itbit_asp_net_core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace itbit_asp_net_core.model
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; } 

    }
}