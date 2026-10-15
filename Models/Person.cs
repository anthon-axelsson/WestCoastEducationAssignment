namespace WestCoastEducationAssignment.Models;

public class Person : IPerson
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PersonalNumber { get; set; }
    public required string Address { get; set; }
    public required string PostalCode { get; set; }
    public required string Region { get; set; }
    public virtual string GetDetails()
    {
        return $"Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Personal Number: {PersonalNumber}, Address: {Address}, Postal Code: {PostalCode}, Region: {Region}";
    }

}
