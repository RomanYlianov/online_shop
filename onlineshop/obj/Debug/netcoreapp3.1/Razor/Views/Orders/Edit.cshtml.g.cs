#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "319f633a4611ffbe9af843494e8be5f7338509143b0d04b2c3c0c91c7591e230"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Edit), @"mvc.1.0.view", @"/Views/Orders/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"319f633a4611ffbe9af843494e8be5f7338509143b0d04b2c3c0c91c7591e230", @"/Views/Orders/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.OrderDTO>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
  
    ViewBag.Title = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Order</h2>\r\n\r\n");
#nullable restore
#line 9 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
 using (Html.BeginForm("Edit", "Orders", FormMethod.Post))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "319f633a4611ffbe9af843494e8be5f7338509143b0d04b2c3c0c91c7591e2304064", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 12 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <h4>Order</h4>\r\n        <br />\r\n\r\n        ");
#nullable restore
#line 20 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 21 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 22 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
   Write(Html.HiddenFor(model=>model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 23 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
   Write(Html.HiddenFor(model=>model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 24 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
   Write(Html.HiddenFor(model=>model.BuyerDTOId));

#line default
#line hidden
#nullable disable
            WriteLiteral("       \r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 27 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.BuyerDTO.FullName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 29 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.BuyerDTO.FullName, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.BuyerDTO.FullName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 35 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.BuyerDTO.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 37 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.BuyerDTO.Email, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 38 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.BuyerDTO.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.BuyerDTO.Country, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.BuyerDTO.Country, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 46 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.BuyerDTO.Country, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 51 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.BuyerDTO.Address, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 53 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.BuyerDTO.Address, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.BuyerDTO.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 59 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.ProductDTOs, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                <ul>\r\n");
#nullable restore
#line 62 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
                     foreach (var item in Model.ProductDTOs)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>");
#nullable restore
#line 64 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 65 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 71 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.Count, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 73 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.Count, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 74 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Count, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 79 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.Price, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 81 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.Price, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 82 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Price, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--delivery method-->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 89 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.DeliveryMethodDTOId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 91 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.DeliveryMethodDTO.Name, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 92 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.DeliveryMethodDTO.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--paymetmethod-->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 99 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.PaymentMethodDTOId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 101 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.PaymentMethodDTO.Name, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 102 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.PaymentMethodDTO.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--order status-->      \r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 109 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.OrderStatus, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 111 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.OrderStatus.Value, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 112 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.OrderStatus, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--mark -->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 119 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.Mark, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 121 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.Mark, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 122 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Mark, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n      \r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 130 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
       Write(Html.LabelFor(model => model.Price, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 132 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.EditorFor(model => model.Price, new { htmlAttributes = new { @class = "form-control", disabled = "disabled", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 133 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Price, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>


        <div class=""form-group row"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Save"" class=""btn btn-default"" />
            </div>
        </div>

    </div>
");
#nullable restore
#line 145 "G:\VS projects\onlineshop\onlineshop\Views\Orders\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
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
