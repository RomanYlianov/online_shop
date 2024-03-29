#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6452be0bc9b507080d6f6775ca9046c3da7fb60c51429f8c8b4155b1c5309690"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"6452be0bc9b507080d6f6775ca9046c3da7fb60c51429f8c8b4155b1c5309690", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.ProductDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Products list</h2>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 10 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
Write(Html.ActionLink("Create new", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n");
#nullable restore
#line 13 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
 using(Html.BeginForm("Index","Products", FormMethod.Get))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label for=\"nid\">Name</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"nid\" name=\"name\"/>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"cid\">Category name</label>\r\n        ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
   Write(Html.DropDownList("category", ViewBag.Categories as IEnumerable<SelectListItem>,"select category", new { @class = "form-control", @id="cid"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"sfid\">suppler firm</label>\r\n        ");
#nullable restore
#line 25 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
   Write(Html.DropDownList("supplerFirmIds", (MultiSelectList)ViewBag.SupplerFirms, new { multiple = "multiple", @class="form-control", @id="sfid", @size="2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
      
    </div>
    <div class=""form-group"">
        <label for=""lpid"">lowest price</label>
        <input type=""text"" class=""form-control"" id=""lpid"" name=""lowestPrice"" />
    </div>
    <div class=""form-group"">
        <label for=""hpid"">higest price</label>
        <input type=""text"" class=""form-control"" id=""hpid"" name=""higestPrice"" />
    </div>
    <div class=""form-group"">
        <label for=""lrid"">lowest rating</label>
        <input type=""text"" class=""form-control"" id=""lrid"" name=""lowestRating"" />
    </div>
    <div class=""form-group"">
        <label for=""hrid"">higest rating</label>
        <input type=""text"" class=""form-control"" id=""hrid"" name=""higestRating"" />
    </div>
    <div class=""form-check"">
        <input type=""checkbox"" class=""form-check-input"" id=""ihid"" name=""isHot"" />
        <label for=""ihid"" class=""form-check-label"">is hot</label>        
    </div>
    <div class=""form-group"">
        <button type=""submit"" class=""btn btn-primary"">send</button>
    </div>
");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                Category\r\n            </td>\r\n            <td>\r\n                Suppler firm\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 74 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.IsHot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td colspan=\"3\">\r\n                Details &ensp; Update &nbsp; Delete\r\n            </td>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n        \r\n");
#nullable restore
#line 90 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    \r\n                    <td>\r\n                        ");
#nullable restore
#line 97 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.CategoryDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.SupplerFirmDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.CountAll));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n                    <td>\r\n                        ");
#nullable restore
#line 114 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 117 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 119 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                     if (item.IsHot == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            yes\r\n                        </td>\r\n");
#nullable restore
#line 124 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            not\r\n                        </td>\r\n");
#nullable restore
#line 130 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                    <td colspan=\"3\">\r\n                        ");
#nullable restore
#line 133 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 134 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 135 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 139 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
               
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"11\">no data</td>\r\n            </tr>\r\n");
#nullable restore
#line 147 "G:\VS projects\onlineshop\onlineshop\Views\Products\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n    \r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.ProductDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
