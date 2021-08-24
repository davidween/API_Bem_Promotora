using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {

        }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {

        }
        
        public virtual DbSet<Treina_Cliente> TREINA_CLIENTES { get; set; }
        public virtual DbSet<Treina_Proposta> TREINA_PROPOSTAS { get; set; }
        public virtual DbSet<Treina_Usuario> TREINA_USUARIOS { get; set; }
        public virtual DbSet<Treina_Conveniada> TREINA_CONVENIADAS { get; set; }
    }
}