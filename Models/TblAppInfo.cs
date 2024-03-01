using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblAppInfo
{
    public string CodeProject { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string? ServerPath { get; set; }

    public string? Description { get; set; }

    public bool IsSetup { get; set; }

    public string? FileId { get; set; }

    public bool? EnforceUpdate { get; set; }

    public DateTime? PublishDate { get; set; }
}
