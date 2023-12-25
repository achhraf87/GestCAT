using GESTCAT.DOMAIN.Models;
using System;
using System.Collections.Generic;

namespace GESTCAT.DOMAIN.Models;

public partial class Catalogue
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public DateTime? DateModif { get; set; }

    public int? LivreId { get; set; }

    public virtual Livre? Livre { get; set; }
}
