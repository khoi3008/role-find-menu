using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblUpdateFile
{
    public string FileId { get; set; } = null!;

    public byte[]? FileContent { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? PublishDate { get; set; }

    public bool? IsRarfile { get; set; }

    public string? FileName { get; set; }
}
