using System;
using System.Collections.Generic;

namespace MediaCenters.Models;

public partial class MediaTag
{
    public int Id { get; set; }

    public int? MediaId { get; set; }

    public int? TagId { get; set; }

    public int? Type { get; set; }
}
