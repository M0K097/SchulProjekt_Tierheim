using System;
using System.Collections.Generic;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

public partial class Tiere
{
    public int TierId { get; set; }

    public string? Tierart { get; set; }

    public string? Tiername { get; set; }

    public DateTime? Geburtsdatum { get; set; }

    public string? Beschreibung { get; set; }

    public virtual ICollection<Anfragen> Anfragen { get; set; } = new List<Anfragen>();

      
}
