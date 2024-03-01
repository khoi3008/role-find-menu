using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models;

public partial class TblFormControl
{
    public int Id { get; set; }

    public string? ControlType { get; set; }

    public string PropName { get; set; } = null!;

    public string? PropStyleController { get; set; }

    public int PropTop { get; set; }

    public int PropLeft { get; set; }

    public int PropWidth { get; set; }

    public int PropHeigh { get; set; }

    public int PropAnchor { get; set; }

    public int PropDoc { get; set; }

    public int PropBackColor { get; set; }

    public short PropIsKnownBackColor { get; set; }

    public int PropForeColor { get; set; }

    public short PropIsKnownForeColor { get; set; }

    public string PropFontName { get; set; } = null!;

    public double PropFontSize { get; set; }

    public short PropFontStyle { get; set; }

    public short PropFontGdiCharSet { get; set; }

    public short PropFontStrikeout { get; set; }

    public short PropFontUnderline { get; set; }

    public short? PropEnable { get; set; }

    public short? PropVisible { get; set; }

    public string? PropParent { get; set; }

    public string? FunctionName { get; set; }

    public string LayoutName { get; set; } = null!;

    public string? DefaultValue { get; set; }

    public string? PropLabel { get; set; }

    public int PropTabIndex { get; set; }

    public virtual TblLayout LayoutNameNavigation { get; set; } = null!;
}
