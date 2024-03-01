using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblRoleSystemPermission
{
    public string RoleName { get; set; } = null!;

    public string PermissionName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual TblSystemPermission PermissionNameNavigation { get; set; } = null!;

    public virtual TblRole RoleNameNavigation { get; set; } = null!;
}
