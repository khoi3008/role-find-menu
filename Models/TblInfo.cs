﻿using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblInfo
{
    public string IName { get; set; } = null!;

    public string IValue { get; set; } = null!;

    public string? IComment { get; set; }
}
