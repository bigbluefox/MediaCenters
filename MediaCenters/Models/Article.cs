using System;
using System.Collections.Generic;

namespace MediaCenters.Models;

public partial class Article
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Source { get; set; }

    public string? Abstract { get; set; }

    public string? Content { get; set; }

    public DateTime? CreateTime { get; set; }
}
