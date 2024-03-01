using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblLayoutPermission
{
    public string UserName { get; set; } = null!;

    public string LayoutName { get; set; } = null!;

    public bool IsDefault { get; set; }

    public virtual TblLayout LayoutNameNavigation { get; set; } = null!;

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
