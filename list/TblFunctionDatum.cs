using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblFunctionDatum
{
    public string FunctionName { get; set; } = null!;

    public string ObjectName { get; set; } = null!;

    public int Ins { get; set; }

    public int Upd { get; set; }

    public int Del { get; set; }

    public int Sel { get; set; }

    public int Exc { get; set; }

    public string ObjectType { get; set; } = null!;
}
