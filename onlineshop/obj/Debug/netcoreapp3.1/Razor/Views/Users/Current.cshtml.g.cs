#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0b7442ce9214197712eca24950eb3d5378b8d35b3e6702a56c850ecdd72dcd0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Current), @"mvc.1.0.view", @"/Views/Users/Current.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0b7442ce9214197712eca24950eb3d5378b8d35b3e6702a56c850ecdd72dcd0d", @"/Views/Users/Current.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Current : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.UserDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
  
    ViewBag.Title = "Current";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Current User</h2>\r\n\r\n<div class=\"container\">\r\n\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 18 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 26 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 34 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 38 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 42 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 46 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 50 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 58 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 62 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 66 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 70 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 74 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
#nullable restore
#line 78 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
         if (Model.IsVIP == true)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 82 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
           Write(Html.DisplayNameFor(model=>model.IsVIP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n");
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                VIP user\r\n            </dd>\r\n");
#nullable restore
#line 88 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \r\n       \r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 93 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 97 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            User roles\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            <ul>\r\n");
#nullable restore
#line 106 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                 foreach (var item in ViewBag.UserRoles)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 108 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 109 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            Manage suppler firms\r\n        </dt>\r\n\r\n");
#nullable restore
#line 118 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
         if (ViewBag.SupplerFirms != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                <ul>\r\n");
#nullable restore
#line 122 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                     foreach (var item in ViewBag.SupplerFirms)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>");
#nullable restore
#line 124 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 125 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </dd>\r\n");
#nullable restore
#line 128 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                the user is not a representative of any company\r\n            </dd>\r\n");
#nullable restore
#line 134 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </dl>\r\n\r\n</div>\r\n\r\n<p>\r\n    \r\n    ");
#nullable restore
#line 143 "G:\VS projects\onlineshop\onlineshop\Views\Users\Current.cshtml"
Write(Html.ActionLink("Back", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.UserDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
