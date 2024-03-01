using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblMessage
{
    public string Code { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? MsCause { get; set; }

    public string? MsAction { get; set; }

    public int MsIcon { get; set; }

    public int MsButton { get; set; }

    public int MsButtonDefault { get; set; }

    public string MsCaption { get; set; } = null!;

    public virtual ICollection<TblMessageLang> TblMessageLangs { get; set; } = new List<TblMessageLang>();
}
