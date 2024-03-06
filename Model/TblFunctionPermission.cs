using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblFunctionPermission
{
    public string UserName { get; set; } = null!;

    public string FunctionName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string PermissionType { get; set; } = null!;

    public virtual TblFunction FunctionNameNavigation { get; set; } = null!;
}
