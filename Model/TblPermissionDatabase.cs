using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblPermissionDatabase
{
    public string PermissionName { get; set; } = null!;

    public string Pdatabase { get; set; } = null!;

    public virtual TblSystemPermission PermissionNameNavigation { get; set; } = null!;
}
