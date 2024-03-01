using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblUserSystemPermission
{
    public string UserName { get; set; } = null!;

    public string PermissionName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual TblSystemPermission PermissionNameNavigation { get; set; } = null!;

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
