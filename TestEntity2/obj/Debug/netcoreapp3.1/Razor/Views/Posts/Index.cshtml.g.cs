#pragma checksum "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92ebfca1d31960309b8ccf945f17887c2a536a7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts_Index), @"mvc.1.0.view", @"/Views/Posts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92ebfca1d31960309b8ccf945f17887c2a536a7b", @"/Views/Posts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e952839e5498335092cdb3faa573d533791ac67", @"/Views/_ViewImports.cshtml")]
    public class Views_Posts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
  
    ViewData["Title"] = "Mes articles";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col s12 m12"">
        <div class=""row valign-wrapper"">
            <div class=""col s6"">
                <h4 class=""header"">Mes super articles</h4>
            </div>
            <div class=""col s6 right-align"">
                ");
#nullable restore
#line 15 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
           Write(Html.ActionLink("Ajouter un article", 
                                 "Create", 
                                 "Posts", 
                                 new { area = "" }, 
                                 new { @class = "waves-effect waves-light btn" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
         foreach (var post in ViewBag.Posts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card horizontal\">\r\n                <div class=\"card-stacked\">\r\n                    <div class=\"card-content\">\r\n                        <span class=\"card-title\">");
#nullable restore
#line 27 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
                                            Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <p>");
#nullable restore
#line 28 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
                      Write(post.Content.Substring(0, Math.Min(post.Content.Length, 50)));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</p>\r\n                    </div>\r\n                    <div class=\"card-action\">\r\n                        <a href=\"#\">Lire la suite</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\ib\source\repos\TestEntity2\TestEntity2\Views\Posts\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
