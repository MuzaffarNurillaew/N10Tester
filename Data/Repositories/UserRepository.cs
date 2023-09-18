using Microsoft.VisualBasic;
using N10Tester.Domain.Entities;
using Newtonsoft.Json;
using Constants = N10Tester.Data.Config.Constants;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace N10Tester.Data.Repositories;

public class UserRepository : IUserRepository
{
    public Student Create(Student student)
    {
        var students = GetAll();
        var updatedStudents = students.ToList();
        updatedStudents.Add(student);
        WriteAll(updatedStudents);
        return student;
    }

    public bool Delete(long id)
    {
        var students = GetAll();
        var foundedStudent = students.FirstOrDefault(x => x.Id == id);
        if (foundedStudent != null)
        {
            var updatedStudents = students.ToList();
            updatedStudents.Remove(foundedStudent);
            WriteAll(updatedStudents);
            return true;
        }

        return false;
    }

    public IEnumerable<Student> GetAll()
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

    public bool WriteAll(IEnumerable<Student> students)
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
            foundedStudent.UpdatedAt = DateTime.Now;

            WriteAll(students);
        }

        return student;
    }
}