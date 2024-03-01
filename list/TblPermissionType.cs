using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblPermissionType
{
    public string Code { get; set; } = null!;

    public string PropName { get; set; } = null!;

    public string PropCaption { get; set; } = null!;

    public int Pos { get; set; }

    public string? UseType { get; set; }
}
