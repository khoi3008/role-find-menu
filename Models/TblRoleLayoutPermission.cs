using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblRoleLayoutPermission
{
    public string RoleName { get; set; } = null!;

    public string LayoutName { get; set; } = null!;

    public bool IsDefault { get; set; }

    public virtual TblLayout LayoutNameNavigation { get; set; } = null!;

    public virtual TblRole RoleNameNavigation { get; set; } = null!;
}
