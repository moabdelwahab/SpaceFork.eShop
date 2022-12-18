using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = new Guid();
            CreateionDate = DateTime.UtcNow;
        }

        public IntegrationBaseEvent(Guid id, DateTime createionDate)
        {
            Id = id;
            CreateionDate = createionDate;
        }

        public Guid Id { get; private set; } = new Guid();
        public DateTime CreateionDate { get; private set; } = DateTime.UtcNow;

    }
}
