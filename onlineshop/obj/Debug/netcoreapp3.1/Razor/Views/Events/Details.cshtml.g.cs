#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "732b646adf89c1da7b42840ed7279bc77c44ce558976f6f194c6bb6942b96586"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Details), @"mvc.1.0.view", @"/Views/Events/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"732b646adf89c1da7b42840ed7279bc77c44ce558976f6f194c6bb6942b96586", @"/Views/Events/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.EventDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
  
    ViewBag.Title = "Event details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Event</h2>\r\n\r\n<div class=\"container\">\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 13 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 17 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.ProductDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model=>model.ProductDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 29 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 33 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 41 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.ExpirationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
         if (Model.ExpirationTime != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                ");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model=>model.ExpirationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 53 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                not set\r\n            </dd>\r\n");
#nullable restore
#line 59 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dl>\r\n</div>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 66 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
Write(Html.ActionLink("Product details", "Details", "Products", new {id = Model.ProductDTOId}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Events\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.EventDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
