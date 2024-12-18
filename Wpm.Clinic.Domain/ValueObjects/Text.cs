namespace Wpm.Clinic.Domain.ValueObjects;

public class Text
{
    public string Value {get; set;}
    public Text(string value)
    {
        Value = value;
    }

    private void Validate(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("value", "Text is not valid");
        }

        if(value.Length > 500)
        {
            throw new ArgumentException("Text too large");
        }
    }

    public static implicit operator Text(string value)
    {
        return new Text(value);
    }
}

