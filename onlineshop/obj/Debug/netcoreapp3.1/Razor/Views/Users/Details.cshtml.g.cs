#pragma checksum "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "09c32347f127d1b6e1d295fc5f4da12fde6bc2ac4f4cd60c7319431db37a5733"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"09c32347f127d1b6e1d295fc5f4da12fde6bc2ac4f4cd60c7319431db37a5733", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.UserDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>User details</h2>\r\n\r\n<div class=\"container\">\r\n\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 14 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 18 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 22 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 26 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 30 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 34 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 38 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 42 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 46 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 50 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 54 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 58 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 62 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 66 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 70 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 74 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 78 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.IsVIP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 82 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.IsVIP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 86 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 90 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            User roles\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            <ul>\r\n");
#nullable restore
#line 99 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                 foreach (var item in ViewBag.UserRoles)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 101 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 102 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n           \r\n        </dd>\r\n\r\n\r\n       \r\n        <dt class=\"col-sm-3\">\r\n            Manage suppler firms\r\n        </dt>\r\n\r\n");
#nullable restore
#line 113 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
         if (ViewBag.SupplerFirms != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                <ul>\r\n");
#nullable restore
#line 117 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                     foreach (var item in ViewBag.SupplerFirms)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>");
#nullable restore
#line 119 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 120 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </dd>\r\n");
#nullable restore
#line 123 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                the user is not a representative of any company\r\n            </dd>\r\n");
#nullable restore
#line 129 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      \r\n\r\n    </dl>\r\n\r\n</div>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 138 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 139 "D:\документы\WEB SITE\release\onlineshop\Views\Users\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

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
