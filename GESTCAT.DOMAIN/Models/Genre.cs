using System;
using System.Collections.Generic;

namespace GESTCAT.DOMAIN.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
}
