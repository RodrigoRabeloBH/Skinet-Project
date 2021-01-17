namespace Skinet.Model.OrderAggregate
{
    public class ShippingAddress : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ShippingAddress() { }

        public ShippingAddress(string firstName, string lastName, string street, int number, string city, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}