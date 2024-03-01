using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblButtonLang
{
    public string Button { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public string? Content { get; set; }
}
