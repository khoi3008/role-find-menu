using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class VwLayoutPrj
{
    public string? FunctionDesc { get; set; }

    public string LayoutName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public string? FunctionName { get; set; }

    public byte[]? FormImage { get; set; }

    public string? Version { get; set; }

    public byte[]? LayoutContent { get; set; }

    public string? CodeProject { get; set; }
}
