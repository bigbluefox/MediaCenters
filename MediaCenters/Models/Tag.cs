using System;
using System.Collections.Generic;

namespace MediaCenters.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Type { get; set; }
}
