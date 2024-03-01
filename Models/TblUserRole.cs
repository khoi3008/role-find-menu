using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblUserRole
{
    public int UserRoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual TblRole RoleNameNavigation { get; set; } = null!;

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
