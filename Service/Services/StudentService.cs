using N10Tester.Data.Config;
using N10Tester.Domain.Entities;
using N10Tester.Service.Interface;
using Newtonsoft.Json;

namespace N10Tester.Service.Services;

internal class StudentService : IStudentService
{
    public Student Create(Student student)
    {
        throw new NotImplementedException();
    }

    public bool Delete(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetAll()
    {
        string source = null;
        if (File.Exists(Constants.STUDENT_DB))
            source = File.ReadAllText(Constants.STUDENT_DB);

        if (!string.IsNullOrWhiteSpace(source))
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<Student>>(source);

            return users;
        }
    }

    public Student GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Student Update(Student student)
    {
        throw new NotImplementedException();
    }
}
