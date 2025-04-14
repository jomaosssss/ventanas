using System;
using System.Collections.Generic;

namespace nuevo.Models;

public partial class Mantenimiento
{
    public int NumActFijo { get; set; }

    public string ClaveDivision { get; set; } = null!;

    public string ClaveZona { get; set; } = null!;

    public string ClaveAgencia { get; set; } = null!;

    public string ClaveTipoMtto { get; set; } = null!;

    public DateTime FechaProgramada { get; set; }
}
