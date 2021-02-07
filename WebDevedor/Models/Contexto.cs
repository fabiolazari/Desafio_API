using LibraryDesafioAPI.Classes;
using System.Data.Entity;

namespace WebDevedor.Models
{
    public class Contexto : DbContext
    {
        
        public Contexto() : base("MsDesafioAPI")
        {

        }

        public DbSet<Devedor> Devedor { get; set; }

    }
}
