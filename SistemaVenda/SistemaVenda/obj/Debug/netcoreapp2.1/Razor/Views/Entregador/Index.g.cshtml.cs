#pragma checksum "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6af3dabd1a12b3d7ca3cdba45459bfddae587987"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entregador_Index), @"mvc.1.0.view", @"/Views/Entregador/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Entregador/Index.cshtml", typeof(AspNetCore.Views_Entregador_Index))]
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
#line 1 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda;

#line default
#line hidden
#line 2 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6af3dabd1a12b3d7ca3cdba45459bfddae587987", @"/Views/Entregador/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9542d2a040dc74eba97c4a394c73aefd7909e77c", @"/Views/_ViewImports.cshtml")]
    public class Views_Entregador_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaVenda.Models.EntregadorViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(104, 49, true);
            WriteLiteral("\r\n<h2>Cadastros de entregadores</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(153, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdc375a64455486bb70b8415401402c0", async() => {
                BeginContext(176, 14, true);
                WriteLiteral("Cadastrar novo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(194, 313, true);
            WriteLiteral(@"
</p>



<table class="" table table-bordered"">
    <thead>
        <tr>
            <th>Ações</th>
            <th scope=""col"">Nome</th>
            <th scope=""col"">Foto<th>
            <th scope=""col"">IdCidadeEntrega<th>
            <th scope=""col"">id<th>
        </tr>
    </thead>
	<tbody>
		
");
            EndContext();
#line 27 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
         foreach (var item in Model)
		{

#line default
#line hidden
            BeginContext(544, 26, true);
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 570, "\"", 604, 2);
            WriteAttributeValue("", 577, "Entregador/Edit?id=", 577, 19, true);
#line 31 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
WriteAttributeValue("", 596, item.Id, 596, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(605, 20, true);
            WriteLiteral(">Editar</a>\r\n\t\t\t\t\t<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 625, "\"", 672, 3);
            WriteAttributeValue("", 632, "javascript:apagar(", 632, 18, true);
#line 32 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
WriteAttributeValue("", 650, item.Id, 650, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 658, ",\'Entregador\')", 658, 14, true);
            EndWriteAttribute();
            BeginContext(673, 39, true);
            WriteLiteral(">Apagar</a>\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(713, 39, false);
#line 35 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(752, 28, true);
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(781, 39, false);
#line 38 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Foto));

#line default
#line hidden
            EndContext();
            BeginContext(820, 28, true);
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(849, 50, false);
#line 41 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdCidadeEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(899, 28, true);
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(928, 37, false);
#line 44 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(965, 29, true);
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t\r\n\t\t\t</tr>\r\n");
            EndContext();
#line 48 "C:\Sistema Comida\SistemaComida2\SistemaVenda\SistemaVenda\Views\Entregador\Index.cshtml"
		}

#line default
#line hidden
            BeginContext(999, 21, true);
            WriteLiteral("\t</tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaVenda.Models.EntregadorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
