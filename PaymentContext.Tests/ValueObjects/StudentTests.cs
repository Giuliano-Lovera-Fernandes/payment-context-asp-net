using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var name = new Name("João", "Kustner");
            var document = new Document("32345678908", EDocumentType.Cpf);
            var email = new Email("batman@dc.com");
            var address = new Address("Avenida", "2094", "Praia do Morro", "Guarapari", "Es", "Brasil", "29216010");
            
            var student = new Student(name, document, email, address, Guid.NewGuid());

            var subscription = new Subscription(DateTime.Now, Guid.NewGuid());
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", document, address, email, Guid.NewGuid());
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription);

            Assert.IsFalse(student.IsValid);

        }

        public void ShouldReturnSuccessWhenHadActiveSubscription()
        {

        }
    }

}

