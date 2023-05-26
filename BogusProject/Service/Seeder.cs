using BogusProject.Database;
using BogusProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusProject.Service
{
    public static class Seeder
    {
        public static void InitialSeed()
        {
            using (var context = new ApplicationContext())
            {
                if (!context.Positions.Any() || !context.Workers.Any())
                {
                    context.Positions.Add(new Position
                    {
                        Title = "Продавец",
                        Salary = 30_000,
                    });
                    context.Positions.Add(new Position
                    {
                        Title = "Старший продавец",
                        Salary = 45_000,
                    });
                    context.Positions.Add(new Position
                    {
                        Title = "Директор",
                        Salary = 80_000,
                    });
                    context.Positions.Add(new Position
                    {
                        Title = "Товаровед",
                        Salary = 60_000,
                    });
                    context.SaveChanges();

                    List<Worker> workers = FakerStudent.getGeneratorWorker().Generate(100);
                    foreach (var worker in workers)
                    {
                        context.Workers.Add(worker);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
