using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwRole2role
{
    public string RoleName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Description { get; set; }

    public bool IsSystem { get; set; }

    public string ProleName { get; set; } = null!;
}
