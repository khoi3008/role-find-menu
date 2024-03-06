using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class VwMessageLang
{
    public string Code { get; set; } = null!;

    public string? Message { get; set; }

    public string? MsCause { get; set; }

    public string? MsAction { get; set; }

    public int MsIcon { get; set; }

    public int MsButton { get; set; }

    public int MsButtonDefault { get; set; }

    public string? MsCaption { get; set; }

    public string Lang { get; set; } = null!;
}
