using Flunt.Notifications;

namespace Opea.GestaoBiblioteca.Domain.Entities
{
    public abstract class EntityBase : Notifiable<Notification>
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; set; } 
        public DateTime DataCriacao { get; set; }

        public abstract bool Validar();
    }
}
