#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1f62f2ae89c35dcfe458cbc88dbb375db504f9f984502f1d6efe5d14b26cfd32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Index), @"mvc.1.0.view", @"/Views/Users/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1f62f2ae89c35dcfe458cbc88dbb375db504f9f984502f1d6efe5d14b26cfd32", @"/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.UserDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Users list</h2>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 10 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
Write(Html.ActionLink("Create new", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n");
#nullable restore
#line 13 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
 using(Html.BeginForm("Index", "Users", FormMethod.Get))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label for=\"unid\">user name</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"unid\" name=\"userName\" />\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""form-group"">
        <label for=""eid"">email</label>
        <input type=""text"" class=""form-control"" id=""eid"" name=""email"" />
    </div>
    <div class=""form-group"">
        <label for=""pnid"">phone number</label>
        <input type=""text"" class=""form-control"" id=""pnid"" name=""phoneNumber"" />
    </div>
    <div class=""form-group"">
        <label for=""rid"">Role</label>
        ");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
   Write(Html.DropDownList("roleIds", (MultiSelectList)ViewBag.Roles, new { multiple = "multiple", @class="form-control", @id="rid", @size="2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        <button type=\"submit\" class=\"btn btn-primary\">send</button>\r\n    </div>\r\n");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 59 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td colspan=\"3\">\r\n                Details &ensp; Update &nbsp; Delete\r\n            </td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 73 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 79 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 85 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 88 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td colspan=\"3\">\r\n                        ");
#nullable restore
#line 91 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 92 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 93 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 96 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"9\">no data</td>\r\n            </tr>\r\n");
#nullable restore
#line 103 "G:\VS projects\onlineshop\onlineshop\Views\Users\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.UserDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
