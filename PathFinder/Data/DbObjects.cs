using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;
using PathFinder.Data.Models.Users;

namespace PathFinder.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context, IConfigurationRoot config)
        {
            if (!context.Races.Any())
                context.AddRange(new List<Race>
                {
                    new Race
                    {
                        Name = "Люди",
                        Description =
                            @"Люди столь же разнообразны, как и условия их обитания. От смуглых кочевников южных земель до бледных варваров северных морей люди отличаются разнообразием цвета кожи, типом сложения и чертами лица. В целом чем ближе люди живут к экватору, тем темнее у них кожа."
                    },
                    new Race
                    {
                        Name = "Эльфы",
                        Description =
                            @"Эльфы обычно выше людей, но обладают более хрупким и изящным сложением и длинными заостренными ушами. У эльфов большие миндалевидные глаза с крупными, ярко окрашенными радужками. Хотя в эльфийских нарядах обычно отражается красота природы, эльфы, живущие в городах, одеваются по последней моде."
                    }
                });

            if (!context.CharClasses.Any())
                context.AddRange(new List<CharClass>
                {
                    new CharClass
                    {
                        Name = "Воин",
                        Description = "Могучие воители"
                    },
                    new CharClass
                    {
                        Name = "Жрец",
                        Description = "Служители боов"
                    }
                });

            if (!context.Roles.Any()) context.Roles.AddRange(Roles.Select(r => r.Value));

            if (!context.Users.Any())
            {
                var admin = config.GetSection("Config").GetSection("AdminUser");
                context.Add(new User
                {
                    Email = admin.GetSection("Login").Value,
                    Password = admin.GetSection("Password").Value,
                    Name = "admin",
                    Created = DateTime.Now,
                    Role = Roles["admin"]
                });
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Role> _roles;

        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    var list = new List<Role>
                    {
                        new Role
                        {
                            Name = "admin"
                        },
                        new Role
                        {
                            Name = "master"
                        },
                        new Role
                        {
                            Name = "user"
                        }
                    };

                    _roles = new Dictionary<string, Role>();
                    foreach (var element in list) _roles.Add(element.Name, element);
                }

                return _roles;
            }
        }
    }
}