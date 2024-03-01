using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblMenuRole
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public int MenuId { get; set; }

    public virtual TblMenu Menu { get; set; } = null!;

    public virtual TblRole RoleNameNavigation { get; set; } = null!;
}
