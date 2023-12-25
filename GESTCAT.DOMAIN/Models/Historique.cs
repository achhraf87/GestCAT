using System;
using System.Collections.Generic;

namespace GESTCAT.DOMAIN.Models;

public partial class Historique
{
    public int Id { get; set; }

    public int? LivreId { get; set; }

    public int? AuteurId { get; set; }

    public virtual Auteur? Auteur { get; set; }

    public virtual Livre? Livre { get; set; }
}
