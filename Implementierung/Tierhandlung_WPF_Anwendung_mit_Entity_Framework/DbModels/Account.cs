using System;
using System.Collections.Generic;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

public partial class Account
{
    public int NutzerId { get; set; }

    public string? Benutzername { get; set; }

    public string? Passwort { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<Anfragen> Anfragen { get; set; } = new List<Anfragen>();
}
