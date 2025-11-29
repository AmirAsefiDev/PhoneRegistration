namespace PhoneRegistration.Domain;

public class PhoneNumber
{
    public int Id { get; set; }
    public string Mobile { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}