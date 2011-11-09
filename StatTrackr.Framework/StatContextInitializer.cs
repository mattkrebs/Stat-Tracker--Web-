﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework.Security;

namespace StatTrackr.Framework
{
    public class StatContextInitializer : DropCreateDatabaseIfModelChanges<StatContext>
    {
        protected override void Seed(StatContext context)
        {

            CodeFirstSecurity.CreateAccount("krebs", "drinksonm3", "krebs44@gmail.com");


            new List<Role>{
                new Role{ RoleName="Administrator"},
                new Role{ RoleName="Owner"},
                new Role{ RoleName="Edit Team"},
                new Role{ RoleName="Edit Leauge"},
                new Role{ RoleName="Edit Division"},
                new Role{ RoleName="Edit Player"},
                new Role{ RoleName="Edit Stats"}
            }.ForEach(r => context.Roles.Add(r));

            context.SaveChanges();

            new List<Division>
            {
                new Division{ Name="Men's Open", DateCreated=DateTime.Now},
                new Division{ Name="Men's Recreational", DateCreated=DateTime.Now}
            }.ForEach(d => context.Divisions.Add(d));

            new List<League>
            {
                new League{ Name="Bloomington South", DateCreated=DateTime.Now},
                new League{ Name="Bloomington South", DateCreated=DateTime.Now},
                new League{ Name="Target Center", DateCreated=DateTime.Now},                
                new League{ Name="Fridley",  DateCreated=DateTime.Now},
                new League{ Name="Champlin", DateCreated=DateTime.Now},
                new League{ Name="Champlin", DateCreated=DateTime.Now}
            }.ForEach(l => context.Leagues.Add(l));

            new List<Team>
            {
                new Team{ TeamName="Abe Froman",  DateCreated=DateTime.Now},
                new Team{ TeamName="Rebels", DateCreated=DateTime.Now},
                new Team{ TeamName="Celtics", DateCreated=DateTime.Now},
                new Team{ TeamName="Los Gouchos", DateCreated=DateTime.Now},
                new Team{ TeamName="Saints", DateCreated=DateTime.Now},
                new Team{ TeamName="Rockets", DateCreated=DateTime.Now}

            }.ForEach(t => context.Teams.Add(t));

            new List<Player>
            {
                new Player { Name="Matt Krebs", Number=2, Position="Center", Experiance="College", Height="6'8\"", Weight="270", TwitterHandle="mattkrebs", DateCreated=DateTime.Now},
                new Player { Name="Hans Hennen", Number=8, Position="Forward", Experiance="College", Height="6'3\"", Weight="210", TwitterHandle="hwh3nn3n", DateCreated=DateTime.Now},
                new Player { Name="Nels Fogalberg", Number=2, Position="Center", Experiance="College", Height="6'8\"", Weight="170", DateCreated=DateTime.Now},
                new Player { Name="Ryan Janson", Number=4, Position="Guard", Experiance="High School", Height="5'11\"", Weight="210",TwitterHandle="ryjans", DateCreated=DateTime.Now},
                new Player { Name="Nate", Number=23, Position="Guard", Experiance="College", Height="6'2\"", Weight="190", DateCreated=DateTime.Now}
                


            }.ForEach(p => context.Players.Add(p));


            new List<Region>
            {
                new Region { Name="Minnesota", TimeZone="CST" }
            }.ForEach(r => context.Regions.Add(r));


            base.Seed(context);
        }
    }
}