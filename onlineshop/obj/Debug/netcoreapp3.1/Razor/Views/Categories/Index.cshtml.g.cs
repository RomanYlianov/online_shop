#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a65b94a20d7fe6da03de223afea469d1facc1f179aa2d0c5ad0c9c3bc65ece68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Index), @"mvc.1.0.view", @"/Views/Categories/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\VS projects\onlineshop\onlineshop\Views\_ViewImports.cshtml"
using onlineshop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\VS projects\onlineshop\onlineshop\Views\_ViewImports.cshtml"
using onlineshop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a65b94a20d7fe6da03de223afea469d1facc1f179aa2d0c5ad0c9c3bc65ece68", @"/Views/Categories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Categories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.CategoryDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Categories list</h2>\r\n\r\n");
#nullable restore
#line 9 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
 if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 12 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
   Write(Html.ActionLink("Create new", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                Details\r\n            </td>\r\n");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    Edit\r\n                </td>\r\n                <td>\r\n                    Delete\r\n                </td>\r\n");
#nullable restore
#line 38 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 42 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 47 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                   Write(Html.DisplayFor(modeItem=>item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                        \r\n                    </td>\r\n");
#nullable restore
#line 53 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                     if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 56 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 61 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 63 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
             
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"5\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 72 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"3\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 78 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "G:\VS projects\onlineshop\onlineshop\Views\Categories\Index.cshtml"
             
           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.CategoryDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
