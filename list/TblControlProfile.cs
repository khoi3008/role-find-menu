using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblControlProfile
{
    public string ProfileName { get; set; } = null!;

    public string FunctionName { get; set; } = null!;

    public string ControlType { get; set; } = null!;

    public string ControlName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime LastDay { get; set; }

    public byte[]? Content { get; set; }

    public virtual TblFunction FunctionNameNavigation { get; set; } = null!;

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
