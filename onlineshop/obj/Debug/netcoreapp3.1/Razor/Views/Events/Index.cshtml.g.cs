#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b3ca1e46ed84bf49b90931bf343f44980127c54b20ccecd52f72bbd8f1398e58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Index), @"mvc.1.0.view", @"/Views/Events/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b3ca1e46ed84bf49b90931bf343f44980127c54b20ccecd52f72bbd8f1398e58", @"/Views/Events/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.EventDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Events list</h2>\r\n\r\n");
#nullable restore
#line 9 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
 if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 12 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
   Write(Html.ActionLink("Create new", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.ProductDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.ExpirationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Details\r\n            </th>\r\n");
#nullable restore
#line 36 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    Edit\r\n                </th>\r\n                <th>\r\n                    Delete\r\n                </th>\r\n");
#nullable restore
#line 44 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 57 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.ProductDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n");
#nullable restore
#line 64 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                     if (item.ExpirationTime != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                       Write(Html.DisplayFor(modelItem=>item.ExpirationTime.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            not set\r\n                        </td>\r\n");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 77 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n");
#nullable restore
#line 80 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                     if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 83 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 86 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 88 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 91 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
             
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"7\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 100 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"5\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 106 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "G:\VS projects\onlineshop\onlineshop\Views\Events\Index.cshtml"
             
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.EventDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
