using ApiRestVisualContact.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestVisualContact.Migrations
{
    public class VisualContactDBContext(DbContextOptions<VisualContactDBContext> options) : DbContext(options)
    {


        public DbSet<Agente> agentesdb => Set<Agente>();

    }
        //internal class VisualContactDBContext : DbContext
        //{
        //    //public VisualContactDBContext(DbContextOptions<VisualContactDBContext> options): base(options)
        //    //{

        //    //}

        //    public DbSet<Agente> agentesdb { get; set; }

        //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    //{
        //    //    base.OnModelCreating(modelBuilder);

        //    //    modelBuilder.Entity<Agente>().HasData(agentesdb);
        //    //}

        //}
 }