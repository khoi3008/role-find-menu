using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblText
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public string? Enctext { get; set; }

    public string? Dectext { get; set; }
}
