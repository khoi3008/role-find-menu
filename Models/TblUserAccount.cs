using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblUserAccount
{
    public string UserName { get; set; } = null!;

    public byte[]? Password { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? FullName { get; set; }

    public string? Description { get; set; }

    public string? LayoutDefault { get; set; }

    public string? ToolBarDefault { get; set; }

    public byte[]? Signature { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public virtual ICollection<TblControlProfile> TblControlProfiles { get; set; } = new List<TblControlProfile>();

    public virtual ICollection<TblLayoutDefault> TblLayoutDefaults { get; set; } = new List<TblLayoutDefault>();

    public virtual ICollection<TblLayoutPermission> TblLayoutPermissions { get; set; } = new List<TblLayoutPermission>();

    public virtual ICollection<TblReportPermission> TblReportPermissions { get; set; } = new List<TblReportPermission>();

    public virtual ICollection<TblUserRole> TblUserRoles { get; set; } = new List<TblUserRole>();

    public virtual ICollection<TblUserSystemPermission> TblUserSystemPermissions { get; set; } = new List<TblUserSystemPermission>();
}
