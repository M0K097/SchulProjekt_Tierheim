using System;
using System.Collections.Generic;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

public partial class Anfragen
{
    public int AnfrageId { get; set; }

    public int? NutzerId { get; set; }

    public int? TierId { get; set; }
    public string? Status { get; set; }
    public string? TextInfo { get; set; }

    public virtual Account? Nutzer { get; set; }

    public virtual Tiere? Tier { get; set; }
}
