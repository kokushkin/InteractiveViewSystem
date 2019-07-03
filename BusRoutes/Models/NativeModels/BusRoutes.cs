using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.NativeModels
{
    public class BusRoutesContext : DbContext
    {
        public BusRoutesContext()
            : base("name=BusRoutes")
        {
        }

        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<RoutesOfTown> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoutesOfTown>()
                .HasMany(e => e.Routes)
                .WithOptional()
                .Map(tn => tn.MapKey("TownId"));

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Stations)
                .WithOptional()
                .Map(rt => rt.MapKey("RouteId"));


            modelBuilder.Entity<Route>()
                .HasOptional(e => e.BeginStation)
                .WithOptionalPrincipal()
                .Map(rt => rt.MapKey("StationBegionOfIdRoute"));


            modelBuilder.Entity<Route>()
                .HasOptional(e => e.EndStation)
                .WithOptionalPrincipal()
                .Map(rt => rt.MapKey("StationEndOfIdRoute"));
        }
    }
}
