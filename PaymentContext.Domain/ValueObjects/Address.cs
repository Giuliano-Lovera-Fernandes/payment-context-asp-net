using Flunt.Validations;

namespace PaymentContext.Shared.ValueObject
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neigborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neigborhood = neigborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new CreateAddressContract(this));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neigborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }

    public class CreateAddressContract : Contract<Address>
    {
        public CreateAddressContract(Address address)
        {
            Requires()
                .IsLowerThan(address.Street, 3, "address.Street", "Nome da rua deve conter pelo menos 3 caracteres");

        }
    }
}

