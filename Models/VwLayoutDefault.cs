using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwLayoutDefault
{
    public string UserName { get; set; } = null!;

    public string LayoutName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public string? FunctionName { get; set; }

    public string? Version { get; set; }
}
