#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7e066c785f5fa7bfc663159ec57b6419c8a9761dfdc867b9089409cddaff8eac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Details), @"mvc.1.0.view", @"/Views/Products/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e066c785f5fa7bfc663159ec57b6419c8a9761dfdc867b9089409cddaff8eac", @"/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.ProductDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Product details</h2>\r\n\r\n<div class=\"container\">\r\n\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 18 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.CategoryDTO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 26 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.CategoryDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.SupplerFirmDTO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 34 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.SupplerFirmDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 38 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 42 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        \r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 47 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n      \r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 56 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 60 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        \r\n        \r\n");
#nullable restore
#line 64 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
         if (Model.IsHot == true)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 68 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
           Write(Html.DisplayNameFor(model=>model.IsHot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n");
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                HOT PRODUCT!\r\n            </dd>\r\n");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 79 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 83 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 91 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
 if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 94 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n        ");
#nullable restore
#line 95 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
   Write(Html.ActionLink("Add event","Create", "Events", new { id = Model.Id } ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 97 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<br/>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 104 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
Write(Html.ActionLink("show comments", "Index", "Comments", new {id=Model.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    |\r\n    ");
#nullable restore
#line 107 "G:\VS projects\onlineshop\onlineshop\Views\Products\Details.cshtml"
Write(Html.ActionLink("Back to List", "Catalog"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.ProductDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
