#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f86be5d0d5a97628eac5e0b2fcbee4b02c169778cf9e4b948635a678b25be550"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SupplerFirms_Index), @"mvc.1.0.view", @"/Views/SupplerFirms/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f86be5d0d5a97628eac5e0b2fcbee4b02c169778cf9e4b948635a678b25be550", @"/Views/SupplerFirms/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SupplerFirms_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.SupplerFirmDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
  
    ViewBag.Text = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Suppler firms list</h2>\r\n\r\n");
#nullable restore
#line 9 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
 if (ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 12 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
   Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<table class=\"table\">\r\n    \r\n    <thead>\r\n\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Details\r\n            </th>\r\n");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
             if (ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    Update\r\n                </th>\r\n                <th>\r\n                    Delete\r\n                </th>\r\n");
#nullable restore
#line 56 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
            }           

#line default
#line hidden
#nullable disable
            WriteLiteral("           \r\n        </tr>\r\n        \r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 63 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 72 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 78 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 81 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 84 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 87 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 90 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                       \r\n                        \r\n                    </td>\r\n");
#nullable restore
#line 94 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                     if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 97 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 100 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 102 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 104 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
             
        }
        else
        {

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"9\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 115 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"7\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 121 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Index.cshtml"
             


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.SupplerFirmDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
