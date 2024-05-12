using Flunt.Validations;
using PaymentContext.Shared.Entity;
namespace PaymentContext.Domain.Entities

{
    public class Subscription : Entity
    {
        //Observe que nesse caso, o _payments será a lista que será lida, mas antes deve ser iniciada no construtor.
        private IList<Payment> _payments;

        //Ao criar um objeto, observe que o CreateDate e o LastUpDateDate serão sempre o objeto atual.
        //Não será recebido um active, pois ao trabalhar com uma subscription, assumimos que ela está inativa e será ativada
        //ou que ela está ativa e será desativada (depende do modelo de pagamento definido, pode ser que a assinatura será criada)
        //somente ao realizar o pagamento, ou se cria a assinatura e espera um pagamento. No negócio criado, sempre virá com 
        //um pagamento junto.
        //O expireDate - quando boleto terá uma data de expiração.
        public Subscription(DateTime? expireDate, Guid guid)
            :base(guid)
        {   
            CreateDate = DateTime.Now;
            LastUpDateDate = DateTime.Now;        
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpDateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        //public IReadOnlyCollection<Payment> Payments { get; private set; }
        
        //Observe que a propriedade de somente leitura, não fará a leitura de Subscriptions, mas sim de _subscription.
        public IReadOnlyCollection<Payment> Payments { get {return _payments.ToArray();} }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new CreateSubscriptionContract(payment));
            
            //if (Valid) só adiciona se for válido
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpDateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpDateDate = DateTime.Now;
        }
    }

    public class CreateSubscriptionContract : Contract<Payment>
    {
        
        public CreateSubscriptionContract(Payment payment)
        {
            
            Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscriptions.Payments", "A data do pagamento deve ser futura");
        }
    }

}

