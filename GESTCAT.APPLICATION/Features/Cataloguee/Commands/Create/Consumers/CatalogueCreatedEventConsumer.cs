using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create.Events;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create.Consumers
{
    public class CatalogueCreatedEventConsumer : IConsumer<CatalogueCreatedEvent>
    {
        public Task Consume(ConsumeContext<CatalogueCreatedEvent> context)
        {
            var mss = context.Message.Title;
            return Task.CompletedTask;
        }
    }
}
