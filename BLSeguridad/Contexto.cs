using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BLFacturacionSB
{
    class Contexto : DbContext
    {
        public Contexto() : base("Clientes")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
     public DbSet<Cliente> Clientes { get; set; }
    }
        
 }
    

