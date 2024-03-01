using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblProject
{
    public string CodeProject { get; set; } = null!;

    public string? Description { get; set; }

    public string Owner { get; set; } = null!;

    public string ServerName { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
