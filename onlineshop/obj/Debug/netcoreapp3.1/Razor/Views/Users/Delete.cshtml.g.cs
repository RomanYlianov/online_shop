#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99c2e2bce52f409fb3117a21f92c6312cf68fd4290e40400b339e322678634a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Delete), @"mvc.1.0.view", @"/Views/Users/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"99c2e2bce52f409fb3117a21f92c6312cf68fd4290e40400b339e322678634a9", @"/Views/Users/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.UserDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
  
    ViewBag.Title = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n\r\n<div class=\"container\">\r\n    <h4>User</h4>\r\n    <br/>\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 17 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 29 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 33 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 41 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 49 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 53 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 57 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 61 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 73 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 77 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 81 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.IsVIP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n");
#nullable restore
#line 84 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
         if (Model.IsVIP)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                yes\r\n            </dd>\r\n");
#nullable restore
#line 89 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-9\">\r\n                no\r\n            </dd>\r\n");
#nullable restore
#line 95 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      \r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 100 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 104 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
#nullable restore
#line 109 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 115 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 117 "G:\VS projects\onlineshop\onlineshop\Views\Users\Delete.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.UserDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
