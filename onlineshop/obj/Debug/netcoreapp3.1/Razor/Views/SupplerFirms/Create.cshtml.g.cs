#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "db41af5725e84242e786013528a54ef78fc8e144c21ac36c6ce9e5df70d5357e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SupplerFirms_Create), @"mvc.1.0.view", @"/Views/SupplerFirms/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"db41af5725e84242e786013528a54ef78fc8e144c21ac36c6ce9e5df70d5357e", @"/Views/SupplerFirms/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SupplerFirms_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.SupplerFirmDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
  
    ViewBag.Tittle = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Suppler firm</h2>\r\n\r\n");
#nullable restore
#line 9 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
 using (Html.BeginForm("Create", "SupplerFirms", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
                            ;


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <h4>suppler firm</h4>\r\n        <br/>\r\n        ");
#nullable restore
#line 16 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 17 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 20 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 23 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.Address, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.EditorFor(model => model.Address, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 31 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--country-->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 38 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.Country, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.DropDownListFor(model=>model.Country, ViewBag.Countries as IEnumerable<SelectListItem>, new { @class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Country, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--date-->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.RegisterDate, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 50 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.EditorFor(model => model.RegisterDate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.RegisterDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>        \r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 56 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.Rating, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 58 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.EditorFor(model => model.Rating, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 59 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Rating, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n      \r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
       Write(Html.LabelFor(model => model.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 67 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.EditorFor(model => model.Description, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 68 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 79 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 83 "G:\VS projects\onlineshop\onlineshop\Views\SupplerFirms\Create.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.SupplerFirmDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
