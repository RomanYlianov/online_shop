#pragma checksum "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "29ca913b795576ae33f52c4e8a946961c8a5dbd17e7a93c80c39972d18edbe64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeliveryMethods_Index), @"mvc.1.0.view", @"/Views/DeliveryMethods/Index.cshtml")]
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
#line 1 "D:\документы\WEB SITE\release\onlineshop\Views\_ViewImports.cshtml"
using onlineshop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\документы\WEB SITE\release\onlineshop\Views\_ViewImports.cshtml"
using onlineshop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"29ca913b795576ae33f52c4e8a946961c8a5dbd17e7a93c80c39972d18edbe64", @"/Views/DeliveryMethods/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_DeliveryMethods_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.DeliveryMethodDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>delivery methods list</h2>\r\n\r\n");
#nullable restore
#line 9 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
 if (ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 12 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
   Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 14 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                Details\n            </th>\r\n");
#nullable restore
#line 31 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
             if (ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    Edit\r\n                </th>\r\n                <th>\r\n                    Delete\r\n                </th>\r\n");
#nullable restore
#line 39 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 45 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 50 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 51 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                   Write(Html.DisplayFor(modeItem=>item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                       \r\n                        \r\n                    </td>\r\n");
#nullable restore
#line 56 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                     if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 59 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 64 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 66 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
             
        }
        else
        {

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
             if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"5\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 76 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"3\">no data</td>\r\n                </tr>\r\n");
#nullable restore
#line 82 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\документы\WEB SITE\release\onlineshop\Views\DeliveryMethods\Index.cshtml"
             

            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.DeliveryMethodDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
