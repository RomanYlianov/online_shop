#pragma checksum "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f386498f96f6a8ea470fce54e33548993b855c7a3bb2210a6f77876ffa75d6d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SupplerFirms_Details), @"mvc.1.0.view", @"/Views/SupplerFirms/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f386498f96f6a8ea470fce54e33548993b855c7a3bb2210a6f77876ffa75d6d6", @"/Views/SupplerFirms/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SupplerFirms_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.SupplerFirmDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Suppler firm details</h2>\r\n\r\n<div class=\"container\">\r\n    <h4>suppler firm</h4>\r\n    <br/>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 14 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 17 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 20 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 23 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 26 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 29 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 32 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 35 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 38 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 41 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 44 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 47 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 50 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 53 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n</div>\r\n\r\n");
#nullable restore
#line 59 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
 if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 62 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </p>\r\n");
#nullable restore
#line 65 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br/>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 70 "D:\документы\WEB SITE\release\onlineshop\Views\SupplerFirms\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.SupplerFirmDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
