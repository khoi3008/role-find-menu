using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class VwUserRole
{
    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsSystem { get; set; }

    public string UserName { get; set; } = null!;
}
