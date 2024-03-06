using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual ICollection<TblMenuRole> TblMenuRoles { get; set; } = new List<TblMenuRole>();
}
