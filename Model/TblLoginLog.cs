using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblLoginLog
{
    public DateTime LoginDate { get; set; }

    public string UserName { get; set; } = null!;

    public string? MacAddress { get; set; }

    public string? ComputerName { get; set; }

    public int? Status { get; set; }

    public string? Project { get; set; }
}
