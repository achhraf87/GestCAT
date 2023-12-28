using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogList;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList;
using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GESTCAT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LivresController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLivreListViewModal>>> getAllLivre()
        {
            var dtos = await _mediator.Send(new GetCatalogueListQuery());
            return Ok(dtos);
        }
    }
}
