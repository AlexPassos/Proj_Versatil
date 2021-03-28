#pragma checksum "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37b7dd359949ef3ad42f40c86bfcef84014c503b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bancos__IndexResult), @"mvc.1.0.view", @"/Views/Bancos/_IndexResult.cshtml")]
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
#line 1 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\_ViewImports.cshtml"
using Versatil.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\_ViewImports.cshtml"
using Versatil.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\_ViewImports.cshtml"
using Versatil.Domain.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\_ViewImports.cshtml"
using Versatil.Domain.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\_ViewImports.cshtml"
using Versatil.Domain.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37b7dd359949ef3ad42f40c86bfcef84014c503b", @"/Views/Bancos/_IndexResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80952516e066ea2d70119ec88fa7fa8714026be", @"/Views/_ViewImports.cshtml")]
    public class Views_Bancos__IndexResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Versatil.Domain.ViewModels.BancosViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table id=""table-data"" class=""table table-striped table-hover dataTable"" role=""grid"">
    <thead>
        <tr role=""row"">
            <th class=""sorting_asc text-sm"" tabindex=""0"" aria-controls=""table-data"" rowspan=""1"" colspan=""1""
                aria-sort=""ascending"">
                Nome do banco</th>
            <th class=""colEditar text-sm"">Editar</th>
            <th class=""colExcluir text-sm"">Excluir</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 15 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr role=\"row\" class=\"odd\">\r\n                <td class=\"sorting_1 text-md\">");
#nullable restore
#line 18 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
                                         Write(Html.DisplayFor(model => item.descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-center\">\r\n                    <button class=\"btn bg-gradient-secondary btn-sm btneditar\" \r\n                        data-url=\"");
#nullable restore
#line 21 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
                             Write(Url.Action("Edit", new {id = item.id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                        data-loading-text=""...""><i class=""fas fa-edit""></i>
                    </button>
                </td>
                <td class=""text-center"">
                    <button class=""btn bg-gradient-danger btn-sm btnexcluir""
                        data-url=""");
#nullable restore
#line 27 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
                             Write(Url.Action("Delete", new {id = item.id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-nome=\"");
#nullable restore
#line 28 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
                              Write(item.descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-loading-text=\"...\"><i class=\"fas fa-trash\"></i>\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "D:\Projetos_AspNetCore\Proj_Versatil\src\Versatil.Web\Views\Bancos\_IndexResult.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Versatil.Domain.ViewModels.BancosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
