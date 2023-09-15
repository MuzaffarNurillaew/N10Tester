using N10Tester.Domain.Entities;

namespace N10Tester.Service.Interface;

public interface IStudentService
{
    Student Create(Student student);
    Student Update(Student student);
    bool Delete(long id);
    Student GetById(long id);
    IEnumerable<Student> GetAll();
}