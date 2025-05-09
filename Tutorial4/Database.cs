using Tutorial4.Models;

namespace Tutorial4
{
    public static class Database
    {
        public static List<Animal> Animals = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                Name = "Reksio",
                Category = "pies",
                Weight = 10.5,
                FurColor = "brazowy",
                Visits = new List<Visit>
                {
                    new Visit { Id = 1, Date = DateTime.Parse("2024-04-01"), Description = "Szczepienie", Price = 120 },
                    new Visit { Id = 2, Date = DateTime.Parse("2024-05-01"), Description = "Kontrola", Price = 80 }
                }
            },
            new Animal
            {
                Id = 2,
                Name = "Filemon",
                Category = "kot",
                Weight = 4.3,
                FurColor = "czarny",
                Visits = new List<Visit>
                {
                    new Visit { Id = 3, Date = DateTime.Parse("2024-04-15"), Description = "Sterylizacja", Price = 150 },
                    new Visit { Id = 4, Date = DateTime.Parse("2024-05-10"), Description = "Szczepienie na wscieklizne", Price = 100 }
                }
            },
            new Animal
            {
                Id = 3,
                Name = "Burek",
                Category = "pies",
                Weight = 12.2,
                FurColor = "szary",
                Visits = new List<Visit>
                {
                    new Visit { Id = 5, Date = DateTime.Parse("2025-03-25"), Description = "Wazektomia", Price = 130 }
                }
            }
        };
    }
}
