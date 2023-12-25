using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GESTCAT.DOMAIN.Models;

public partial class Auteur
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateNaissance { get; set; }

    public virtual ICollection<Historique> Historiques { get; set; } = new List<Historique>();
}
