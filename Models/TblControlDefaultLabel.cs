using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblControlDefaultLabel
{
    public string FunctionName { get; set; } = null!;

    public string ControlName { get; set; } = null!;

    public string ControlType { get; set; } = null!;

    public string? PropCaption { get; set; }

    public string Lang { get; set; } = null!;

    public string? PropParent { get; set; }

    public string? PropHint { get; set; }
}
