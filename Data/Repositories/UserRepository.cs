using N10Tester.Domain.Entities;
using Newtonsoft.Json;
using Constants = N10Tester.Data.Config.Constants;

namespace N10Tester.Data.Repositories;

public class UserRepository : IUserRepository
{
    public Student Create(Student student)
    {
        if (!Directory.Exists(student.ProjectPath))
            throw new DirectoryNotFoundException($"{student.ProjectPath} not found!");

        if (!Directory.Exists(Path.Combine(student.ProjectPath, ".git")))
            throw new DirectoryNotFoundException("Git directory not found!");
            
        student.CreatedAt = DateTime.UtcNow;
        var students = GetAll();
        if (!students.Any())
        {
            student.Id = 1;
        }
        else
        {
            student.Id = students.Max(x => x.Id) + 1;
        }
        students.Add(student);
        WriteAll(students);
        return student;
    }

    public bool Delete(long id)
    {
        var students = GetAll();
        var foundedStudent = students.FirstOrDefault(x => x.Id == id);
        if (foundedStudent != null)
        {
            students.Remove(foundedStudent);
            WriteAll(students);
            return true;
        }

        return false;
    }

    public List<Student> GetAll()
    {
        List<Student> students;

        var allText = File.ReadAllText(Constants.STUDENT_DB);
        if (allText.Length == 0)
        {
            students = new List<Student>();
            return students;
        }
        
        students = JsonConvert.DeserializeObject<List<Student>>(allText);
        return students;
    }

    private bool WriteAll(IEnumerable<Student> students)
    {
        try
        {
            File.WriteAllText(Constants.STUDENT_DB, JsonConvert.SerializeObject(students, Formatting.Indented));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Student GetById(long id)
    {
        return GetAll().FirstOrDefault(student => student.Id == id);
    }

    public Student Update(Student student)
    {
        var students = GetAll();
        var foundedStudent = students.FirstOrDefault(x => x.Id == student.Id);

        if (foundedStudent != null)
        {
            foundedStudent.FirstName = student.FirstName;
            foundedStudent.LastName = student.LastName;
            foundedStudent.ProjectPath = student.ProjectPath;
            foundedStudent.CrmId = student.CrmId;
            foundedStudent.UpdatedAt = DateTime.UtcNow;

            WriteAll(students);
        }

        return student;
    }
}