#pragma checksum "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93c87a0376dda9a5f481f4d7524296c9569484f6"
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
#line 1 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/_ViewImports.cshtml"
using SistemaVenda;

#line default
#line hidden
#line 2 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/_ViewImports.cshtml"
using SistemaVenda.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93c87a0376dda9a5f481f4d7524296c9569484f6", @"/Views/Entregador/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ba5fa393661f93c9097b858640d2b761b9f9a1", @"/Views/_ViewImports.cshtml")]
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
            BeginContext(60, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(99, 45, true);
            WriteLiteral("\n<h2>Cadastros de entregadores</h2>\n\n<p>\n    ");
            EndContext();
            BeginContext(144, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f65cf9923274d89934b2d9a737858c6", async() => {
                BeginContext(167, 14, true);
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
            BeginContext(185, 261, true);
            WriteLiteral(@"
</p>



<table class="" table table-bordered"">
    <thead>
        <tr>
            <th>Ações</th>
            <th scope=""col"">Nome</th>
            <th scope=""col"">IdCidadeEntrega</th>
            <th scope=""col"">id</th>
        </tr>
    </thead>
	<tbody>
		
");
            EndContext();
#line 26 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
         foreach (var item in Model)
		{

#line default
#line hidden
            BeginContext(481, 24, true);
            WriteLiteral("\t\t\t<tr>\n\t\t\t\t<td>\n\t\t\t\t\t<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 505, "\"", 539, 2);
            WriteAttributeValue("", 512, "Entregador/Edit?id=", 512, 19, true);
#line 30 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
WriteAttributeValue("", 531, item.Id, 531, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(540, 19, true);
            WriteLiteral(">Editar</a>\n\t\t\t\t\t<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 559, "\"", 606, 3);
            WriteAttributeValue("", 566, "javascript:apagar(", 566, 18, true);
#line 31 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
WriteAttributeValue("", 584, item.Id, 584, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 592, ",\'Entregador\')", 592, 14, true);
            EndWriteAttribute();
            BeginContext(607, 36, true);
            WriteLiteral(">Apagar</a>\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
            EndContext();
            BeginContext(644, 39, false);
#line 34 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(683, 26, true);
            WriteLiteral("\n\t\t\t\t</td>\n\n\t\t\t\t<td>\n\t\t\t\t\t");
            EndContext();
            BeginContext(710, 50, false);
#line 38 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdCidadeEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(760, 25, true);
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
            EndContext();
            BeginContext(786, 37, false);
#line 41 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(823, 25, true);
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t\n\t\t\t</tr>\n");
            EndContext();
#line 45 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Entregador/Index.cshtml"
		}

#line default
#line hidden
            BeginContext(852, 19, true);
            WriteLiteral("\t</tbody>\n</table>\n");
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
