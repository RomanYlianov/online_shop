#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "77e620d475cf9a5a8e16995f855f212538b9c87ff54366bba77da6bcc980d15d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Delete), @"mvc.1.0.view", @"/Views/Products/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"77e620d475cf9a5a8e16995f855f212538b9c87ff54366bba77da6bcc980d15d", @"/Views/Products/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.ProductDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
  
    ViewBag.Title = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Product</h2>\r\n\r\n<h3>Are you sure you want to dalete this?</h3>\r\n\r\n<div class=\"container\">\r\n\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 16 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 20 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 24 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.CategoryDTO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.CategoryDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 32 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.SupplerFirmDTO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 36 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.SupplerFirmDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 44 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        \r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 50 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 58 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 62 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 73 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\Products\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
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
