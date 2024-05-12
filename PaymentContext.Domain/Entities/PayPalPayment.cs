using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment    
    {
        public PayPalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, Guid id)
            :base(paidDate, expireDate, total, totalPaid, payer, document, address, email, id)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }

}