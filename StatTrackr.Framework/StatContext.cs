using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using StatTrackr.Framework.Domain;
using System.ComponentModel.DataAnnotations;
namespace StatTrackr.Framework
{
    
    public class StatContext : DbContext
    {
        public StatContext()
            : base("name=StatTrackr")
        {
        }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
