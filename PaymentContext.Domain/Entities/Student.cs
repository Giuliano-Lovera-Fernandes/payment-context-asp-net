using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entity;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        
        //Observe que nesse caso, o _subscriptions será a lista que será lida, mas antes deve ser iniciada no construtor.
        private IList<Subscription> _subscriptions;

        //No momento, não é importante o endereço do aluno (inicialmente), apenas o de cobrança.
        //Com a criação de um construtor, agora não é possível instanciar um aluno sem as características
        //definidas neste.
        public Student(Name name, Document document, Email email, Address address, Guid id)
            :base(id)    
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();

            //Concatenação das notificações.
            AddNotifications(name, document, email);

            //Para exemplificar, podemos criar uma verificação para o nome:
            /* if (firstName.Length == 0)
            {
                throw new Exception("Nome inválido");
            } */
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
       
        //Endereço de entrega.
        public Address Address { get; private set; }
        //public List<Subscription> Subscriptions { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {

            
            //Duas reagras de negócio:
            
            //Se já tiver uma assinatura ativa, cancela e não adiciona uma assinatura nova a ele.

            //Cancela todas as outras assinaturas e coloca esta como principal.

            //inicialmente:
            //foreach (var sub in Subscriptions)
            //{
            //    sub.Active = false;
            //}
        
            /* foreach (var sub in Subscriptions)
            {
                //A assinatura não pode mais ser ativada ou desativada sem passar pelo método.
                sub.Inactivate();
            }

            _subscriptions.Add(subscription); */


            //Percorre todos os subscriptions se tiver algum ativo vou colocar 
            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
            {
                
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            //Alternativa 
            //if(hasSubscriptionActive)
                //AddNotifications("Student.Subscriptions", "Você já tem uma assinatura ativa")

            AddNotifications(new CreateStudentContract(this, hasSubscriptionActive, subscription));

        }
    }

    public class CreateStudentContract: Contract<Student>
    {
        public CreateStudentContract(Student student,  bool hasSubscriptionActive, Subscription subscription)
        {
            Requires()
                .IsFalse(hasSubscriptionActive, "student.Subscriptions", "Você já tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamento");
        }
    }

}