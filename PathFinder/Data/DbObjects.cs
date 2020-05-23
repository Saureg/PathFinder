using System.Collections.Generic;
using System.Linq;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Races.Any())
            {
                context.AddRange(new List<Race>
                {
                    new Race
                    {
                        Name = "Люди",
                        Description = @"Люди столь же разнообразны, как и условия их обитания. От смуглых кочевников южных земель до бледных варваров северных морей люди отличаются разнообразием цвета кожи, типом сложения и чертами лица. В целом чем ближе люди живут к экватору, тем темнее у них кожа."
                    },
                    new Race
                    {
                        Name = "Эльфы",
                        Description = @"Эльфы обычно выше людей, но обладают более хрупким и изящным сложением и длинными заостренными ушами. У эльфов большие миндалевидные глаза с крупными, ярко окрашенными радужками. Хотя в эльфийских нарядах обычно отражается красота природы, эльфы, живущие в городах, одеваются по последней моде."
                    }
                });
            }

            if (!context.CharClasses.Any())
            {
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
            }

            context.SaveChanges();
        }
    }
}