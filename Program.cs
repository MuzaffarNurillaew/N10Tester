using N10Tester.Data.Repositories;
using N10Tester.Domain.Entities;
using N10Tester.Service.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var repo = new UserRepository();

        var service = new StudentService(repo);

        service.Create(new Student(4, "Toshmat", "Gishtmatov", "project/toshmatOff/sln", "ID0"));
        
    }
}