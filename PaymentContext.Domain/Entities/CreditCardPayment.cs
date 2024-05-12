using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardNumber, string cardHolderName, string lastTransactionNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, Guid id)
        : base(paidDate, expireDate, total, totalPaid, payer, document, address, email, id)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }    
}