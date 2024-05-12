using System.Diagnostics.Contracts;
using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new CreateNameContract(this));
                
        }

        public string  FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
                .IsLowerThan(name.FirstName, 3, "O nome deve conter pelo menos 3 carcteres" )
                .IsLowerThan(name.LastName, 3, "O sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(name.FirstName, 40, "O sobrenome deve conter no máximo 40 caracteres");

        }
    }
} 

