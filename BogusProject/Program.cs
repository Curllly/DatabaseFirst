using Bogus;
using BogusProject.Models;
using BogusProject.Service;

/*Faker<Student> generatorStudent = getGeneratorStudent();

Faker<Student> getGeneratorStudent()
{
    return new Faker<Student>("ru")
        .RuleFor(s => s.Fullname, f => f.Name.FullName())
        .RuleFor(s => s.Course, f => f.Random.Byte(1, 4))
        .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber("+7### ### ## ##"))
        .RuleFor(s => s.Group, f => f.Random.ListItem(new List<string>
        {
            "ПР",
            "СГ",
            "ХТ",
            "ПГС"
        }));
}

List<Student> students = generatorStudent.Generate(10000);
foreach (var student in students)
{
    Console.WriteLine(student.Fullname);
    Console.WriteLine(student.Group + "-" + student.Course);
    Console.WriteLine(student.Phone);
}*/

Seeder.InitialSeed();
Console.WriteLine("Начальный посев выполнен!");

