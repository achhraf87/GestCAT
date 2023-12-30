using Flurl.Http;
using Flurl;
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
using GESTCAT.DOMAIN.Models;
using MassTransit.Mediator;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueDetails;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogDetails;

namespace GESTCAT.API.Controllers
{
    [Route("api/Catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly MediatR.IMediator _mediat;
        private readonly ITopicProducer<CatalogueDeletedEvent> _producer;
        public CatalogController(MediatR.IMediator mediat, ITopicProducer<CatalogueDeletedEvent> producer)
        {
            _mediat = mediat;
            _producer = producer;
        }

        [HttpPost("{title}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync(string title)
        {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCatalogueDetailViewModel>> GetPostById(int id)
        {
            var getCatDetailQuery = new GetCatalogueDetailQuery() { Id = id };
            return Ok(await _mediat.Send(getCatDetailQuery));
        }


    }
}
