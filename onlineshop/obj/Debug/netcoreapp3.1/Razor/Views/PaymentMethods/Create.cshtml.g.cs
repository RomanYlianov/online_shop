#pragma checksum "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83a209fdca5bcb65f9521cfd81e1582b01b5a384490eee3dbec44b7e502449bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentMethods_Create), @"mvc.1.0.view", @"/Views/PaymentMethods/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"83a209fdca5bcb65f9521cfd81e1582b01b5a384490eee3dbec44b7e502449bd", @"/Views/PaymentMethods/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b0982cffe213917c79c7be1d61b96d25067f3c82c37ee96fd797ef0bbbf50331", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PaymentMethods_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineshop.Services.DTO.PaymentMethodDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
  
    ViewBag.Title = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Payment method</h2>


<script>
    function f1()
    {
        let arg = document.getElementById('el_pmtype').value;

        let cvvItem = document.getElementById('el_cvv');

        if (arg==0)
        {
            cvvItem.style.visibility = ""visible"";
        }
        else
        {
            cvvItem.style.visibility = ""hidden"";
        }

    }
</script>


");
#nullable restore
#line 30 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
 using (Html.BeginForm("Create", "PaymentMethods", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
                            
    ;


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n\r\n        <h4>Payment method</h4>\r\n        <br />\r\n        ");
#nullable restore
#line 39 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 40 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 43 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 45 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 46 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--dropdown-->\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 52 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.PaymentType, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 54 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.DropDownListFor(model=>model.PaymentType, Html.GetEnumSelectList(typeof(PaymentType)), new { @id="el_pmtype", @onchange="f1();", @class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 55 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.PaymentType, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 61 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.Provider, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 63 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.EditorFor(model => model.Provider, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 64 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Provider, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 69 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.Number, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 71 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.EditorFor(model => model.Number, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 72 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Number, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <!--date-->\r\n\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 79 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.ExpirationDate, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 81 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.EditorFor(model => model.ExpirationDate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 82 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ExpirationDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\" id=\"el_cvv\">\r\n            ");
#nullable restore
#line 87 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
       Write(Html.LabelFor(model => model.CVV, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 89 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.EditorFor(model => model.CVV, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 90 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.CVV, "", new { @class = "text-danger" }));

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
#line 101 "G:\VS projects\onlineshop\onlineshop\Views\PaymentMethods\Create.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineshop.Services.DTO.PaymentMethodDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
