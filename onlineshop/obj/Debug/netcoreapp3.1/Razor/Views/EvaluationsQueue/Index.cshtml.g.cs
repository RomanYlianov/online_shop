#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0f934f1cdfcc1b383dcf1afca010316b19c550cb99fdf90bdc6d2f80df73c90a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EvaluationsQueue_Index), @"mvc.1.0.view", @"/Views/EvaluationsQueue/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0f934f1cdfcc1b383dcf1afca010316b19c550cb99fdf90bdc6d2f80df73c90a", @"/Views/EvaluationsQueue/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_EvaluationsQueue_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<onlineshop.Services.DTO.EvaluationQueueDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Evaluations queue</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.OrderDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.BuyerDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
           Write(Html.DisplayNameFor(model=>model.ProductDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th colspan=\"3\">\r\n                Details &nbsp; Add Comment &nbsp; Mark Product\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
         if (ViewBag.flag == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.OrderDTO.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.BuyerDTO.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.DisplayFor(modelItem=>item.ProductDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td colspan=\"3\">\r\n                        ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 44 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.ActionLink("Add comment", "Create" , "Comments" , new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
                   Write(Html.ActionLink("Rate product", "RateProduct", "Products",new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"6\">no data</td>\r\n            </tr>\r\n");
#nullable restore
#line 55 "G:\VS projects\onlineshop\onlineshop\Views\EvaluationsQueue\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<onlineshop.Services.DTO.EvaluationQueueDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
