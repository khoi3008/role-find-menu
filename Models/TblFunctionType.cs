using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblFunctionType
{
    public string Type { get; set; } = null!;

    public string? Description { get; set; }
}
