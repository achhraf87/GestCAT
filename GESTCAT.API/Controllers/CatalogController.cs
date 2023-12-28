using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogList;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList;
using GESTCAT.APPLICATION.Features.Livree.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GESTCAT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediat;
        public CatalogController(IMediator mediat)
        {
            _mediat = mediat;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCatalogueListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediat.Send(new GetCatalogueListQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateLivreCommand>> AjtLivre(CreateLivreCommand createLivreCommand)
        {
            int id = await _mediat.Send(createLivreCommand);
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCatalogueCommand>> AjtCat(CreateCatalogueCommand createCatalogueCommand)
        {
           int id = await _mediat.Send(createCatalogueCommand);
           return Ok(id);
        }
    }
}
