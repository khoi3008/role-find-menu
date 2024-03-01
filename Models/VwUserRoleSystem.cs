using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwUserRoleSystem
{
    public string UserName { get; set; } = null!;

    public string PermissionName { get; set; } = null!;
}
