#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "37a4175922496b166c32be2a5320953ee695811a225922e8c3a46fe31fe70bba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentMethods_Details), @"mvc.1.0.view", @"/Views/PaymentMethods/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"37a4175922496b166c32be2a5320953ee695811a225922e8c3a46fe31fe70bba", @"/Views/PaymentMethods/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PaymentMethods_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.PaymentMethodDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Payment method details</h2>\r\n\r\n<div class=\"container\">\r\n    <dl class=\"row\">\r\n        \r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 13 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 17 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 24 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 32 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 36 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Provider));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayFor(model => model.Provider));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 44 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
       Write(Html.DisplayFor(model => model.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
         if (Model.ExpirationDate != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ExpirationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n");
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                ");
#nullable restore
#line 58 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
           Write(Html.DisplayFor(model => model.ExpirationDate.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 60 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 62 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
         if (Model.CVV != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.CVV ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-9\">\r\n                ");
#nullable restore
#line 68 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
           Write(Html.DisplayFor(model => model.CVV.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 70 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dl>\r\n</div>\r\n\r\n");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
 if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 78 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 80 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n<p>\r\n   \r\n    ");
#nullable restore
#line 86 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.PaymentMethodDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
