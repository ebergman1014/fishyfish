using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using FishyFish2.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FishyFish2.DAL
{
    public class FishContext : IdentityDbContext<Person>
    {
        public FishContext() : base("Fishy"){}
        public DbSet<Bonus> Bonuses {get; set; }
        public DbSet<Catch> Catches {get; set; }
        public DbSet<Team> Teams {get; set; }
        public DbSet<Membership> Memberships {get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //}
    }
}