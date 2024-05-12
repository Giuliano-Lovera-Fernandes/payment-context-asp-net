using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entity;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.Entities
{
    //Fere o princípio do S de SOLID - Single reponsability principle, por possuir mais de uma classe.
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, Guid id)
            :base(id)
        {
            //No primeiro Replace são retirados todos os traços e substituídos por nada, já no segundo, serão definidas
            //10 posições.
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new CreatePaymentContract(this));
        }

        public string  Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }  

    public class CreatePaymentContract: Contract<Payment>
    {
        public CreatePaymentContract(Payment payment)
        {
            Requires()
                .IsLowerOrEqualsThan(0, payment.Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(payment.Total, payment.TotalPaid, "Payment.TotalPaid", "O total  pago é menor que o valor do pagamento");
        }
    } 

   /*  public class PayPalPayment : Payment
    {
        public string TransactionCode { get; set; }
    } */
}

