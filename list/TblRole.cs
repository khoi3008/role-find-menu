using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblRole
{
    public string RoleName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Description { get; set; }

    public bool IsSystem { get; set; }

    public virtual ICollection<TblMenuRole> TblMenuRoles { get; set; } = new List<TblMenuRole>();

    public virtual ICollection<TblRoleFunctionPermission> TblRoleFunctionPermissions { get; set; } = new List<TblRoleFunctionPermission>();

    public virtual ICollection<TblRoleLayoutPermission> TblRoleLayoutPermissions { get; set; } = new List<TblRoleLayoutPermission>();

    public virtual ICollection<TblRoleReportPermission> TblRoleReportPermissions { get; set; } = new List<TblRoleReportPermission>();

    public virtual ICollection<TblRoleSystemPermission> TblRoleSystemPermissions { get; set; } = new List<TblRoleSystemPermission>();

    public virtual ICollection<TblUserRole> TblUserRoles { get; set; } = new List<TblUserRole>();

    public virtual ICollection<TblRole> RoleNames { get; set; } = new List<TblRole>();

    public virtual ICollection<TblRole> UseRoles { get; set; } = new List<TblRole>();
}
