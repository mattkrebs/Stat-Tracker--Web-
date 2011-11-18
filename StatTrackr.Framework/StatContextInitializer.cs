using System;
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

            CodeFirstSecurity.CreateAccount("joecool", "password", "test@test.com");

            User user = context.Users.Where(x => x.UserID != Guid.Empty).FirstOrDefault();



            //new List<Role>{
            //    new Role{ RoleName="Administrator"},
            //    new Role{ RoleName="Owner"},
            //    new Role{ RoleName="Edit Team"},
            //    new Role{ RoleName="Edit Leauge"},
            //    new Role{ RoleName="Edit Division"},
            //    new Role{ RoleName="Edit Player"},
            //    new Role{ RoleName="Edit Stats"}
            //}.ForEach(r => context.Roles.Add(r));

            context.SaveChanges();


            user.Owner = user;
            user.Roles = new List<Role> { new Role { RoleName = "Administrator" } };
            user.Apis = new List<Api> { new Api { ApiKey = "8e682cad-35ab-476a-a410-0e008150600c", ExparationDate = DateTime.Now.AddMonths(1) } };
            context.Entry(user).State = System.Data.EntityState.Modified;
            context.SaveChanges();


            new List<Division>
            {
                new Division{ Name="Men's Open", DateCreated=DateTime.Now, Owner=user},
                new Division{ Name="Men's Recreational", DateCreated=DateTime.Now, Owner=user}
            }.ForEach(d => context.Divisions.Add(d));

            new List<League>
            {
                new League{ Name="Bloomington South", DateCreated=DateTime.Now, Owner=user, Teams = new List<Team>{
                    new Team{ TeamName="Abe Froman",  DateCreated=DateTime.Now, Owner=user, Players= new List<Player>{
                      new Player { Name="Matt Krebs", Number=2, Position="Center", Experiance="College", Height="6'8\"", Weight="270", TwitterHandle="mattkrebs", DateCreated=DateTime.Now, Owner=user},
                        new Player { Name="Hans Hennen", Number=8, Position="Forward", Experiance="College", Height="6'3\"", Weight="210", TwitterHandle="hwh3nn3n", DateCreated=DateTime.Now, Owner=user}
                 
                    }},
                    new Team{ TeamName="Rebels", DateCreated=DateTime.Now, Owner=user, Players= new List<Player>{
                        new Player { Name="Nels Fogalberg", Number=2, Position="Center", Experiance="College", Height="6'8\"", Weight="170", DateCreated=DateTime.Now, Owner=user},
                        new Player { Name="Ryan Janson", Number=4, Position="Guard", Experiance="High School", Height="5'11\"", Weight="210",TwitterHandle="ryjans", DateCreated=DateTime.Now, Owner=user},
                        new Player { Name="Nate", Number=23, Position="Guard", Experiance="College", Height="6'2\"", Weight="190", DateCreated=DateTime.Now, Owner=user}
                
                    }},
                    new Team{ TeamName="Celtics", DateCreated=DateTime.Now, Owner=user}
                }
                },
                
                new League{ Name="Target Center", DateCreated=DateTime.Now, Owner=user, Teams = new List<Team>{
                    new Team{ TeamName="Los Gouchos", DateCreated=DateTime.Now, Owner=user},
                    new Team{ TeamName="Saints", DateCreated=DateTime.Now, Owner=user},
                    new Team{ TeamName="Rockets", DateCreated=DateTime.Now, Owner=user}
                }},                
                new League{ Name="Fridley",  DateCreated=DateTime.Now, Owner=user},
                new League{ Name="Champlin", DateCreated=DateTime.Now, Owner=user},
                new League{ Name="Champlin", DateCreated=DateTime.Now, Owner=user}
            }.ForEach(l => context.Leagues.Add(l));

    

           

            new List<Region>
            {
                new Region { Name="Minnesota", TimeZone="CST" }
            }.ForEach(r => context.Regions.Add(r));


            base.Seed(context);
        }
    }
}
