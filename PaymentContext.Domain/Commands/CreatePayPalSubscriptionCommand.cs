using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand
    {
        //Os commands nada mais são do que todas as informações necessárias para criar um subscription
        //Serão somente objetos de transporte
        //Os commands pegam a informação de um lugar e passam para outro.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string TransactionCode { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public Document PayerDocumentType { get; set; }
        public EDocumentType Type { get; set; }
        public string PayerEmail { get; set; }        
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}