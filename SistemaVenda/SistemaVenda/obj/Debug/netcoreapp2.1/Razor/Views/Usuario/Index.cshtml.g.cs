#pragma checksum "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91901e88aa057f3ca58d5d2ff6645f728d27a4ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Index), @"mvc.1.0.view", @"/Views/Usuario/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Index.cshtml", typeof(AspNetCore.Views_Usuario_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91901e88aa057f3ca58d5d2ff6645f728d27a4ba", @"/Views/Usuario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ba5fa393661f93c9097b858640d2b761b9f9a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaVenda.Models.UsuarioViewModel>>
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
            BeginContext(57, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(96, 41, true);
            WriteLiteral("\n<h2>Cadastros de usuários</h2>\n\n<p>\n    ");
            EndContext();
            BeginContext(137, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16adf7f8f00542b39ece9c5d71939820", async() => {
                BeginContext(160, 13, true);
                WriteLiteral("Novo Cadastro");
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
            BeginContext(177, 86, true);
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
            EndContext();
            BeginContext(264, 40, false);
#line 16 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(304, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(357, 41, false);
#line 19 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(398, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(451, 41, false);
#line 22 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Senha));

#line default
#line hidden
            EndContext();
            BeginContext(492, 53, true);
            WriteLiteral("\n            </th>\n\n            <th>\n                ");
            EndContext();
            BeginContext(546, 44, false);
#line 26 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Endereco));

#line default
#line hidden
            EndContext();
            BeginContext(590, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(643, 46, false);
#line 29 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ValorGasto));

#line default
#line hidden
            EndContext();
            BeginContext(689, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(742, 38, false);
#line 32 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(780, 80, true);
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 38 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(891, 46, true);
            WriteLiteral("        <tr>\n            <td>\n                ");
            EndContext();
            BeginContext(938, 39, false);
#line 41 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(977, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1030, 40, false);
#line 44 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1070, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1123, 40, false);
#line 47 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Senha));

#line default
#line hidden
            EndContext();
            BeginContext(1163, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1216, 43, false);
#line 50 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Endereco));

#line default
#line hidden
            EndContext();
            BeginContext(1259, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1312, 45, false);
#line 53 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ValorGasto));

#line default
#line hidden
            EndContext();
            BeginContext(1357, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1410, 37, false);
#line 56 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1447, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1500, 65, false);
#line 59 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1565, 19, true);
            WriteLiteral(" |\n                ");
            EndContext();
            BeginContext(1585, 71, false);
#line 60 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1656, 19, true);
            WriteLiteral(" |\n                ");
            EndContext();
            BeginContext(1676, 69, false);
#line 61 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1745, 33, true);
            WriteLiteral("\n            </td>\n        </tr>\n");
            EndContext();
#line 64 "/Users/vitorlupinetti/Desktop/SistemaComida/SistemaComida2/SistemaVenda/SistemaVenda/Views/Usuario/Index.cshtml"
}

#line default
#line hidden
            BeginContext(1780, 23, true);
            WriteLiteral("    </tbody>\n</table>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaVenda.Models.UsuarioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591