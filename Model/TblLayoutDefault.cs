using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblLayoutDefault
{
    public string UserName { get; set; } = null!;

    public string LayoutName { get; set; } = null!;

    public string FunctionName { get; set; } = null!;

    public virtual TblLayout LayoutNameNavigation { get; set; } = null!;

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
