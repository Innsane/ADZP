#pragma checksum "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f36a0e626ddbcf49e0b8e7c13a6c3b6ca891037e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AlgorytmDobieraniaZasobowProdukcyjnych.Pages.Shared.Pages_Shared__DataTable), @"mvc.1.0.view", @"/Pages/Shared/_DataTable.cshtml")]
namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages.Shared
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
#line 1 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\_ViewImports.cshtml"
using AlgorytmDobieraniaZasobowProdukcyjnych;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f36a0e626ddbcf49e0b8e7c13a6c3b6ca891037e", @"/Pages/Shared/_DataTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2c64e08beefb6cdbe0f52063262474da639500", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__DataTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlgorytmDobieraniaZasobowProdukcyjnych.Data.DataTablePartialModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<label>");
#nullable restore
#line 3 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
  Write(Model.TableName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<table style=\"font-size:0.9rem\" ; text-align=\"justify\" , width=\"100%\" cellspacing=\"0\"\r\n       id=\"dataTable\" class=\"table table-sm table-bordered table-hover table-responsive\">\r\n    <thead class=\"thead-light\">\r\n        <tr>\r\n");
#nullable restore
#line 8 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
             foreach (var info in Model.Infos)
            {
                if (info.Name == "Kod")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th id=\"kod\" scope=\"col\">");
#nullable restore
#line 12 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                                        Write(info.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 13 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th");
            BeginWriteAttribute("id", " id=\"", 602, "\"", 617, 1);
#nullable restore
#line 16 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
WriteAttributeValue("", 607, info.Name, 607, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" scope=\"col\">");
#nullable restore
#line 16 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                                               Write(info.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 17 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
         foreach (var data in Model.Datas)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr data-obraz=\"");
#nullable restore
#line 24 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                       Write(data.Obraz);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
#nullable restore
#line 25 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                 foreach (var info in Model.Infos)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 27 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
                   Write(info.GetValue(data));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 28 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_DataTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlgorytmDobieraniaZasobowProdukcyjnych.Data.DataTablePartialModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
