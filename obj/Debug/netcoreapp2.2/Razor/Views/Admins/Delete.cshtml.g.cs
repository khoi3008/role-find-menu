#pragma checksum "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "dcd2d89ad9a8ff0579347d231322a778b1daee141a4afab883908872ad3c1dc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admins_Delete), @"mvc.1.0.view", @"/Views/Admins/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admins/Delete.cshtml", typeof(AspNetCore.Views_Admins_Delete))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"dcd2d89ad9a8ff0579347d231322a778b1daee141a4afab883908872ad3c1dc9", @"/Views/Admins/Delete.cshtml")]
    public class Views_Admins_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleBasedAuthorization.Models.Admins>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
  
    ViewData["Title"] = "Delete Admin";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 93, true);
            WriteLiteral("\r\n<!-- Content Header (Page header) -->\r\n<section class=\"content-header\">\r\n    <h1>\r\n        ");
            EndContext();
            BeginContext(236, 17, false);
#line 11 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(253, 350, true);
            WriteLiteral(@"
    </h1>
</section>
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""row"">
        <!-- left column -->
        <div class=""col-md-12"">
            <h3>Are you sure you want to delete this?</h3>
            <div>
                <dl class=""dl-horizontal"">
                    <dt>
                        ");
            EndContext();
            BeginContext(604, 44, false);
#line 23 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(648, 79, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(728, 40, false);
#line 26 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(768, 79, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(848, 41, false);
#line 29 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(889, 79, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(969, 37, false);
#line 32 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1006, 79, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1086, 41, false);
#line 35 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Roles));

#line default
#line hidden
            EndContext();
            BeginContext(1127, 79, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1207, 43, false);
#line 38 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.Roles.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1250, 175, true);
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n\r\n                <form method=\"post\" action=\"/Admins/DeleteConfirmed\">\r\n                    <input type=\"hidden\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1425, "\"", 1442, 1);
#line 43 "E:\dotnet\RoleBasedAuth_App\RoleBasedAuthorization\Views\Admins\Delete.cshtml"
WriteAttributeValue("", 1433, Model.Id, 1433, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1443, 172, true);
            WriteLiteral(" />\r\n                    <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" />\r\n                </form>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleBasedAuthorization.Models.Admins> Html { get; private set; }
    }
}
#pragma warning restore 1591