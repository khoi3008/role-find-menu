using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwUserSystem
{
    public string UserName { get; set; } = null!;

    public string PermissionName { get; set; } = null!;
}
