using System;
using System.Collections.Generic;

namespace MediaCenters.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
