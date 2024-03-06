using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblReportPermission
{
    public string UserName { get; set; } = null!;

    public string ReportName { get; set; } = null!;

    public int? IsDefault { get; set; }

    public virtual TblUserAccount UserNameNavigation { get; set; } = null!;
}
