namespace N10Tester.Domain.Entities;

public class Student
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProjectPath { get; set; }
    public string CrmId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Student(long id, string firstName, string lastName, string projectPath, string crmId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ProjectPath = projectPath;
        CrmId = crmId;
        CreatedAt = DateTime.Now;
    }
}