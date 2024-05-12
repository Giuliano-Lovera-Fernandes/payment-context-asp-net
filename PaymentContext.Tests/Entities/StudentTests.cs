using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            //var student = new Student();
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Ao declarar uma instância da classe Student, quais informações são necessárias para se ter
            //um aluno? (código pouco expressivo). Caso não pensemos na ideia da elaboração de um construtor, não temos a necessidade
            //de pensar em todas as propriedades que compõe um student.

            //Devemos programar pensando nas pessoas que irão utilizar o código. 
            //O domínio está sendo isolado para uma condição, ser reutilizado.

            //Deve-se escrever um código bom, fácil de se utilizar (as coisas devem ser práticas).
           /*  var student = new Student(
                "Maria",
                "De Marco",
                "1234",
                "florencia@gmail.com",
                "Rua perto da Doceria"
            ); */
            //Perceba que com a presença do construtor, agora não é mais possível instanciar uma aluno sem as características
            //mínimas necessárias, antes era possível instanciar um student, mas quais seriam as suas características?
            //S - single responsability principle - cada item deve somente fazer uma coisa
            
            //Observe que é possível mudar o nome do estudante:
            //student.FirstName = "";
            //Perceba que de fora da classe é possível mudar o nome do student (setar um novo nome sem passar por validação).
            
            //O construtor define um único ponto de entrada para a criação de um student, assim todas as vezes que for necessária
            //a criação, terá que pasar por esse ponto.

            //Poderia ser definida uma validação dentro do construtor, mas a melhor forma é definir o atributo como privado
            //assim, todas as vezes em que for necessário mudar o nome, deverá ser utilizado um método (open close principle).
            //a classe estará aberta para extensões, só que fechada para modificações (ninguém de fora deve modificá-la).        

        }

        [TestMethod]
        public void AdicionarAssinatura()
        {
            var name = new Name("Florencia","De Marco");
            foreach(var not in name.Notifications)
            {
                //not.Message;
            }
            //Agora o subscription necessita de um expire date, mesmo que nulo.
            //var subscription = new Subscription(null);
           /*  var student = new Student("Maria",
                "De Marco",
                "1234",
                "florencia@gmail.com",
                "Rua perto da Doceria"
            ); */

            //student.Subscriptions.Add(subscription); 
            //student.AddSubscription(subscription);
            //Perceba que nesse caso, as assinaturas não serão canceladas, pois não passará pelo método de cancelamento
            //de assinaturas e ainda será adicionada uma nova assinatura.

            //student.Subscriptions.Add(subscription);
            //Esse comando agora gera um erro ao tentar adicionar uma assinatura, pois a lista é apenas de leitura.
            //Agora sim, ao passar por IReadOnlyCollection, não é mais possível Add uma assinatura.
        }
    }
}