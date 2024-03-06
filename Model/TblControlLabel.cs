using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblControlLabel
{
    public string FunctionName { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public byte[]? ControlLabel { get; set; }
}
