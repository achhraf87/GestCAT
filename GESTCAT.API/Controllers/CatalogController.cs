using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create.Events;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogList;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList;
using GESTCAT.APPLICATION.Features.Livree.Commands.Create;
using MassTransit;
using MassTransit.KafkaIntegration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GESTCAT.API.Controllers
{
    [Route("api/Catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediat;
        private readonly ITopicProducer<CatalogueDeletedEvent> _producer;
        public CatalogController(IMediator mediat, ITopicProducer<CatalogueDeletedEvent> producer)
        {
            _mediat = mediat;
            _producer = producer;
        }

        [HttpPost("{title}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync(string title)
        {
            // Another way to access the _topicProducer
            // var _topicProducer = HttpContext.RequestServices.GetRequiredService<ITopicProducer<VideoDeletedEvent>>();

            await _producer.Produce(new CatalogueDeletedEvent
            {
                Title = $"{title}"
            });

            return Ok(title);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCatalogueListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediat.Send(new GetCatalogueListQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCatalogueCommand>> AjtCat(CreateCatalogueCommand createCatalogueCommand)
        {
           int id = await _mediat.Send(createCatalogueCommand);
           return Ok(id);
        }
    }
}
