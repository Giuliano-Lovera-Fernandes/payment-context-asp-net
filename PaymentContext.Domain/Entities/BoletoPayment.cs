using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        //Observe que ao herdar a classe o construtor desta classe (filha) deverá passar os parâmetros para a classe pai.
        public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, Guid id)
            :base(paidDate, expireDate, total, totalPaid, payer, document ,address, email, id) 
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
            
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }         
    }
}