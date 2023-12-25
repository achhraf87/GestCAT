using System;
using System.Collections.Generic;

namespace GESTCAT.DOMAIN.Models;

public partial class Editeur
{
    public int Id { get; set; }

    public string? TitreEditeur { get; set; }

    public DateTime? DateEditeur { get; set; }

    public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
}
