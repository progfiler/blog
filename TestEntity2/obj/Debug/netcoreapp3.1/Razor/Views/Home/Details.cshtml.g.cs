#pragma checksum "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf68a0aa5904dc66ac25f14ce8c1dd04c6f6faff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\_ViewImports.cshtml"
using TestEntity2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\_ViewImports.cshtml"
using TestEntity2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf68a0aa5904dc66ac25f14ce8c1dd04c6f6faff", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e952839e5498335092cdb3faa573d533791ac67", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col s12\">\r\n        <h2>");
#nullable restore
#line 9 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Home\Details.cshtml"
       Write(ViewBag.Post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <div class=\"row\">\r\n            <div class=\"col s12\">\r\n                ");
#nullable restore
#line 12 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Home\Details.cshtml"
           Write(Html.ActionLink("Retour à la liste des articles", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <p>");
#nullable restore
#line 16 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Home\Details.cshtml"
      Write(ViewBag.Post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591