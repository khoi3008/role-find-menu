using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblLayout
{
    public string LayoutName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public string? FunctionName { get; set; }

    public byte[]? FormImage { get; set; }

    public string? Version { get; set; }

    public byte[]? LayoutContent { get; set; }

    public string? CodeLayout { get; set; }

    public virtual TblFunction? FunctionNameNavigation { get; set; }

    public virtual ICollection<TblFormControl> TblFormControls { get; set; } = new List<TblFormControl>();

    public virtual ICollection<TblLayoutDefault> TblLayoutDefaults { get; set; } = new List<TblLayoutDefault>();

    public virtual ICollection<TblLayoutPermission> TblLayoutPermissions { get; set; } = new List<TblLayoutPermission>();

    public virtual ICollection<TblRoleLayoutPermission> TblRoleLayoutPermissions { get; set; } = new List<TblRoleLayoutPermission>();
}
