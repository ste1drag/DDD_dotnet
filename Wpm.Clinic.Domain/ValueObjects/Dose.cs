namespace Wpm.Clinic.Domain.ValueObjects;

public record Dose
{
    public decimal Quantity { get; init; }
    public UnitOfMeasure UoM { get; init; }
    public Dose(decimal quantity, UnitOfMeasure uom) 
    {
        Quantity = quantity;
        UoM = uom;
    }
}

public enum UnitOfMeasure
{
    mg,
    ml,
    tablet
}