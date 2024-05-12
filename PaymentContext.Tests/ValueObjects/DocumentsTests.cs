using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
       //Red, Green, Refactor   
       [TestMethod]
        public void ShouldReturnErrorWhenCnpjIsInvalid()
        {
            var doc = new Document("123456789012", Domain.Enums.EDocumentType.Cnpj);
            
            Assert.IsFalse(doc.IsValid);                
        } 

        [TestMethod]
        public void ShouldReturnSuccessWhenCnpjIsValid()
        {
            var doc = new Document("12345678901234", Domain.Enums.EDocumentType.Cnpj);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCpfIsInvalid()
        {
            var doc = new Document("123456789", Domain.Enums.EDocumentType.Cpf);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678902")]
        [DataRow("32345678901")]
        public void ShouldReturnSuccessWhenCpfIsValid(string test)
        {
            var doc = new Document(test, Domain.Enums.EDocumentType.Cpf);            
            Assert.IsTrue(doc.IsValid);
        } 
    }    
}