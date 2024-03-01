using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.list;

public partial class TblMenu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEng { get; set; }

    public string Icon { get; set; } = null!;

    public string? Url { get; set; }

    public int ParentId { get; set; }

    public string? FunctionName { get; set; }

    public virtual ICollection<TblMenuRole> TblMenuRoles { get; set; } = new List<TblMenuRole>();
}
