using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            //Deve ser criada uma adição de notificação, essa, gera um novo contrato da classe e-mail, que 
            //ao passar pelo método construtor será validado pelo notification do flunt. 
            AddNotifications(new CreateEmailContract(this));
        }

       
        public string Address { get; private set; }
    }

    public class CreateEmailContract : Contract<Email>
    {
        public CreateEmailContract(Email email)
        {
           Requires()
            .IsEmail(email.Address, "Email.Address", "E-mail inválido");   
        }
    }
}  