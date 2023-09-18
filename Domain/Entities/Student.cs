using N10Tester.Domain.Commons;

namespace N10Tester.Domain.Entities;

public class Student : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProjectPath { get; set; }
    public string CrmId { get; set; }

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