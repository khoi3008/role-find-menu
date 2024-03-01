﻿using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblRoleReportPermission
{
    public string RoleName { get; set; } = null!;

    public string ReportName { get; set; } = null!;

    public virtual TblRole RoleNameNavigation { get; set; } = null!;
}
