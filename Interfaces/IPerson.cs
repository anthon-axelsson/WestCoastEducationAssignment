namespace WestCoastEducationAssignment.Interfaces
{
    
};

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string PersonalNumber { get; set; }
    string Address { get; set; }
    string PostalCode { get; set; }
    string Region { get; set; }
    string GetDetails();
}
