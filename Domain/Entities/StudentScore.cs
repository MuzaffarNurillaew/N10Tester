using N10Tester.Domain.Commons;

namespace N10Tester.Domain.Entities;

public class StudentScore : Auditable
{
    public long StudentId { get; set; }
    public float Score { get; set; }
}
