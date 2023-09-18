using N10Tester.Data.Repositories;
using N10Tester.Domain.Entities;
using N10Tester.Service.Interface;

namespace N10Tester.Service.Services;

internal class StudentService : IStudentService
{
    private readonly IUserRepository _userRepository;

    public StudentService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Student Create(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        return _userRepository.Create(student);
    }

    public bool Delete(long id)
    {
        return _userRepository.Delete(id);
    }

    public IEnumerable<Student> GetAll()
    {
        return _userRepository.GetAll();
    }

    public Student GetById(long id)
    {
        return _userRepository.GetById(id);
    }

    public Student Update(Student student)
    {
        return _userRepository.Update(student);
    }
}