using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblSystemPermission
{
    public string PermissionName { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual ICollection<TblRoleSystemPermission> TblRoleSystemPermissions { get; set; } = new List<TblRoleSystemPermission>();

    public virtual ICollection<TblUserSystemPermission> TblUserSystemPermissions { get; set; } = new List<TblUserSystemPermission>();
}
