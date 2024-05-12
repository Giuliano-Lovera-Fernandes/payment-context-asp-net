using System.Diagnostics.Contracts;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new CreateDocumentContract(this));            
        }

       
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public bool Validate()
        {
            if (Type == EDocumentType.Cnpj && Number.Length == 14)
            {
                return true;
            }

            if (Type == EDocumentType.Cpf && Number.Length == 11)
            {
                return true;
            }

            return false;
        }        
    }

    public class CreateDocumentContract : Contract<Document>
    {
        public CreateDocumentContract(Document document)
        {
            Requires()
                .IsTrue(document.Validate(), document.Number, "Documento inválido");
                
        }

    }
}