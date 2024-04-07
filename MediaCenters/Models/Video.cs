using System;
using System.Collections.Generic;

namespace MediaCenters.Models;

public partial class Video
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public int? Size { get; set; }

    public string? Extension { get; set; }

    public string? ContentType { get; set; }

    public string? FullName { get; set; }

    public string? DirectoryName { get; set; }

    public string? Md5 { get; set; }

    public string? Sha1 { get; set; }

    public DateTime? CreationTime { get; set; }
}
