using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblUserDefaultValue
{
    public string UserName { get; set; } = null!;

    public string PropName { get; set; } = null!;

    public string Project { get; set; } = null!;

    public string? PropValue { get; set; }
}
