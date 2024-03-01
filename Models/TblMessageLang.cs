using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblMessageLang
{
    public string Code { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public string? Message { get; set; }

    public string? MsCause { get; set; }

    public string? MsAction { get; set; }

    public string? MsCaption { get; set; }

    public virtual TblMessage CodeNavigation { get; set; } = null!;
}
