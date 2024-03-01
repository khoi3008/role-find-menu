using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblLicenceRegisted
{
    public string MacAddress { get; set; } = null!;

    public string Project { get; set; } = null!;

    public string ComputerName { get; set; } = null!;

    public bool Active { get; set; }

    public string? Description { get; set; }

    public bool IsCheckDate { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? DefaultBranch { get; set; }
}
