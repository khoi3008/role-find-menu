using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblUserTool
{
    public string ToolName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public byte[]? ToolBar { get; set; }
}
