namespace WestCoastEducationAssignment.Models;

public class Person : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string PersonalNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }
    public virtual string GetDetails()
    {
        return $"Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Personal Number: {PersonalNumber}, Address: {Address}, Postal Code: {PostalCode}, Region: {Region}";
    }

}
