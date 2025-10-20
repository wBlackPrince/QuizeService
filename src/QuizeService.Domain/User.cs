namespace QuizeService.Domain;

public class User
{
    private User()
    {
        
    }
    
    public User(
        Guid id,
        string firstName,
        string lastName,
        string middleName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Gets or sets учебный взвод
    /// </summary>
    public string Platoon { get; set; }
}