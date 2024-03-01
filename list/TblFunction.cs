using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblFunction
{
    public string FunctionName { get; set; } = null!;

    public string? FunctionDesc { get; set; }

    public bool? Enabled { get; set; }

    public string? FunctionType { get; set; }

    public string? CodeProject { get; set; }

    public string? Owner { get; set; }

    public string? FormName { get; set; }

    public virtual ICollection<TblControlProfile> TblControlProfiles { get; set; } = new List<TblControlProfile>();

    public virtual ICollection<TblFunctionPermission> TblFunctionPermissions { get; set; } = new List<TblFunctionPermission>();

    public virtual ICollection<TblLayout> TblLayouts { get; set; } = new List<TblLayout>();

    public virtual ICollection<TblRoleFunctionPermission> TblRoleFunctionPermissions { get; set; } = new List<TblRoleFunctionPermission>();
}
