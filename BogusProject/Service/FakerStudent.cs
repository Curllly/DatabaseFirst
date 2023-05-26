using Bogus;
using BogusProject.Database;
using BogusProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusProject.Service
{
    public static class FakerStudent
    {
        public static Faker<Worker> getGeneratorWorker()
        {
            var context = new ApplicationContext();
            int[] positions = context.Positions.Select(p => p.Id).ToArray();


            return new Faker<Worker>("ru")
                .RuleFor(w => w.Name, f => f.Name.FirstName())
                .RuleFor(w => w.Surname, f => f.Name.LastName())
                .RuleFor(w => w.Patronymic, f =>
                {
                    if (f.Person.Gender == Bogus.DataSets.Name.Gender.Male)
                    {
                        return f.Random.ListItem(new List<string>
                        {
                            "Сергеевич",
                            "Андреевич",
                            "Игоревич",
                            "Павлочич",
                            "Ильич",
                            "Артёмович"
                        });
                    }
                    else
                    {
                        return f.Random.ListItem(new List<string>
                        {
                            "Сергеевна",
                            "Андреевна",
                            "Игоревна",
                            "Павловна",
                            "Ильина",
                            "Артёмовна"
                        });
                    }
                })
                .RuleFor(w => w.Phone, f => f.Phone.PhoneNumber("+7-###-###-##-##"))
                .RuleFor(w => w.Birthday, f => f.Person.DateOfBirth)
                .RuleFor(w => w.Address, f => f.Address.FullAddress())
                .RuleFor(w => w.Passport, f => f.Phone.PhoneNumber("#### #####"))
                .RuleFor(w => w.Email, f => f.Person.Email)
                .RuleFor(w => w.PositionId, f => f.Random.ArrayElement(positions));
        }
    }
}
