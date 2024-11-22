namespace Wpm.Clinic.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Consultation_Should_Be_Open()
    {
        Consultation consultation = new Consultation(Guid.NewGuid()) { Status = ConsultationStatus.Open };
        ConsultationStatus consultationStatus = ConsultationStatus.Open;
        Assert.True(consultation.Status == consultationStatus);
    }

    [Fact]
    public void Consultation_Should_Not_End_When_Missing_Data()
    {
        Consultation consultation = new Consultation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(consultation.End);
    }
}