#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e78ec6c0df8805b3e05071ebd3d40be99660de5929d004c3955e1c1e41d12010"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Delete), @"mvc.1.0.view", @"/Views/Events/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e78ec6c0df8805b3e05071ebd3d40be99660de5929d004c3955e1c1e41d12010", @"/Views/Events/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.EventDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
  
    ViewBag.Title = "Event";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Event</h2>\r\n\r\n<h3>Are you sure you want to remove this?</h3>\r\n\r\n<div class=\"container\">\r\n    <h4>Event</h4>\r\n    <br/>\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 17 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.ProductDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 29 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.ProductDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 33 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 41 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 49 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.ExpirationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n");
#nullable restore
#line 52 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
         if (Model.ExpirationTime != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                ");
#nullable restore
#line 55 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
           Write(Html.DisplayFor(model=>model.ExpirationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 57 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                not set\r\n            </dd>\r\n");
#nullable restore
#line 63 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dl>\r\n\r\n");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 73 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 75 "G:\VS projects\onlineshop\onlineshop\Views\Events\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
