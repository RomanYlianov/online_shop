#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "eec9e87d2b4f5933ed557c01115526b5c004d7ce1a8c13c3bdc6a7f9a1c28013"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SupplerFirms_Delete), @"mvc.1.0.view", @"/Views/SupplerFirms/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"eec9e87d2b4f5933ed557c01115526b5c004d7ce1a8c13c3bdc6a7f9a1c28013", @"/Views/SupplerFirms/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SupplerFirms_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.SupplerFirmDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
  
    ViewBag.Titel = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Suppler firm</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n\r\n<div class=\"container\">\r\n    <h4>suppler firm</h4>\r\n    <br />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 16 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 19 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 31 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 34 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 46 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 49 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.MoneyValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 52 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 55 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
#nullable restore
#line 60 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 66 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 68 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
