using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RoleBasedAuthorization.list;

public partial class TblMenuRole
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public int MenuId { get; set; }
    public virtual TblMenu Menu { get; set; }= null!;
       [JsonIgnore]
      public virtual TblRole RoleNameNavigation { get; set; } = null!;
}
