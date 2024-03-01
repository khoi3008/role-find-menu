using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class VwControlLabel
{
    public string FunctionName { get; set; } = null!;

    public string? FunctionDesc { get; set; }

    public string Lang { get; set; } = null!;

    public string? FormName { get; set; }
}
