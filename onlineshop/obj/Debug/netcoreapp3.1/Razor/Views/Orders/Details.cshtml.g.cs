#pragma checksum "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1b9d135bc643a3acbe37d1327018f854f6f3c158087b9ffc70eb9aa34768f85e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
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
#line 1 "D:\документы\WEB SITE\release\onlineshop\Views\_ViewImports.cshtml"
using onlineshop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\документы\WEB SITE\release\onlineshop\Views\_ViewImports.cshtml"
using onlineshop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1b9d135bc643a3acbe37d1327018f854f6f3c158087b9ffc70eb9aa34768f85e", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.OrderDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
  
    ViewBag.Title = "Order details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Order details</h2>\r\n\r\n<div class=\"container\">\r\n    <h4>Order</h4>\r\n    <br/>\r\n\r\n    <dl class=\"row\">\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 16 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 20 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Cipher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 24 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.BuyerDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 28 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.BuyerDTO.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 32 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.ProductDTOs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            <ul>\r\n");
#nullable restore
#line 37 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
                 foreach (var item in Model.ProductDTOs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 39 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 40 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 45 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 49 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 53 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 57 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 61 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.DeliveryMethodDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 65 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.DeliveryMethodDTO.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 69 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.PaymentMethodDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 73 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.PaymentMethodDTO.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 77 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.OrderStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 81 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.OrderStatus.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 85 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.Mark));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 89 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.Mark));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        \r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 93 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.ReceiptCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 97 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.ReceiptCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 101 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.TrackNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 105 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.TrackNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 109 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 113 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model=>model.CreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n    <p>\r\n        ");
#nullable restore
#line 119 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n        ");
#nullable restore
#line 120 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
   Write(Html.ActionLink("Back to MyOrders", "MyOrders"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n\r\n");
#nullable restore
#line 123 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
     if (ViewData["rSeller"] != null || ViewData["rOwner"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            ");
#nullable restore
#line 126 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
       Write(Html.ActionLink("Back to All orders", "AllOrders"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n");
#nullable restore
#line 128 "D:\документы\WEB SITE\release\onlineshop\Views\Orders\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.OrderDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
