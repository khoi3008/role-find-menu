using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class VwUserLayout
{
    public string UserName { get; set; } = null!;

    public string LayoutName { get; set; } = null!;
}
