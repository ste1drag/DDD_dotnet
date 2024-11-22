namespace Wpm.Clinic.Domain.ValueObjects;

public record PatientId
{
    public Guid Value {get; set;}
    public PatientId(Guid value)
    {
        if(value == Guid.Empty)
        {
            throw new ArgumentNullException("value", "The identifier is not valid");
        }
        Value = value;
    }

    public static implicit operator PatientId(Guid value)
    {
        return new PatientId(value);
    }
}