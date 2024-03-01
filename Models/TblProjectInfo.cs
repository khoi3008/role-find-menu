using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblProjectInfo
{
    public string Codeproject { get; set; } = null!;

    public byte[]? Data { get; set; }

    public int? UseThisInfo { get; set; }

    public string? Project { get; set; }
}
