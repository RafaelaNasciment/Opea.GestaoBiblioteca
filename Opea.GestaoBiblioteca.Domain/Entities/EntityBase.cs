using Flunt.Notifications;

namespace Opea.GestaoBiblioteca.Domain.Entities
{
    public abstract class EntityBase : Notifiable<Notification>
    {
        protected EntityBase()
        {            
        }
        public EntityBase(Guid? id, DateTime? dateTime)
        {
            Id = id ?? Guid.NewGuid();
            DataCriacao = dateTime ?? DateTime.Now;
        }

        public Guid Id { get; set; } 
        public DateTime DataCriacao { get; set; }

        public abstract bool Validar();
    }
}
