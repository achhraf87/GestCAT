using GESTCAT.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livree.Commands.Create
{
    public class CreateLivreCommand : IRequest<int>
    {
        public string? Isbn { get; set; }

        public string? Titre { get; set; }

        public DateTime? DatePublication { get; set; }

        public int? NombrePage { get; set; }

        public string? FormatLivre { get; set; }

        public int? EditeurId { get; set; }

        public int? AuteurId { get; set; }

        public string? Couverture { get; set; }

        public bool? IsDisponible { get; set; }

        public string? Langue { get; set; }

        public int? GenreId { get; set; }

        public virtual ICollection<Catalogue> Catalogues { get; set; } = new List<Catalogue>();

        public virtual Editeur? Editeur { get; set; }

        public virtual Genre? Genre { get; set; }

        public virtual ICollection<Historique> Historiques { get; set; } = new List<Historique>();
    }
    
}
