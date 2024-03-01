using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwFormControlDefaultLabel
{
    public string? CodeProject { get; set; }

    public string FunctionName { get; set; } = null!;

    public string? FormName { get; set; }
}
