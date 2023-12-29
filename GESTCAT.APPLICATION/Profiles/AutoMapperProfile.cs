using AutoMapper;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Delete;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Update;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList;
using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreDetails;
using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreList;
using GESTCAT.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Catalogue, CreateCatalogueCommand>().ReverseMap();
            CreateMap<Catalogue, DeleteCatalogueCommand>().ReverseMap();
            CreateMap<Catalogue, UpdateCatalogueCommand>().ReverseMap();
            CreateMap<Catalogue, GetCatalogueListViewModel>().ReverseMap();
            CreateMap<Livre, GetLivreListViewModal>().ReverseMap();
            CreateMap<Livre,GetLivreDetailViewModel>().ReverseMap();
    
        }
    }
}
