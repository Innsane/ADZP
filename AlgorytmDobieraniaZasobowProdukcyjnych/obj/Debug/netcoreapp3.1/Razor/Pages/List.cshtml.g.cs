#pragma checksum "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea44bcf93789c8e9e32347447bb1a3ebe09e6369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AlgorytmDobieraniaZasobowProdukcyjnych.Pages.Pages_List), @"mvc.1.0.razor-page", @"/Pages/List.cshtml")]
namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea44bcf93789c8e9e32347447bb1a3ebe09e6369", @"/Pages/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2c64e08beefb6cdbe0f52063262474da639500", @"/Pages/_ViewImports.cshtml")]
    public class Pages_List : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Tokarki</h1>

<table class=""table table-bordered table-sm"">
    <thead class=""thead-light"">
        <tr>
            <th scope=""col"">Oznaczenie</th>
            <th scope=""col"">Typ</th>
            <th scope=""col"">Kod</th>
            <th scope=""col"">Producent</th>
        </tr>
    </thead>
");
#nullable restore
#line 18 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
     foreach (var lathe in Model.Lathes)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tbody>\r\n            <tr>\r\n                <td scope=\"row\">");
#nullable restore
#line 22 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
                           Write(lathe.Oznaczenie);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
               Write(lathe.Typ);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
               Write(lathe.Kod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
               Write(lathe.Producent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tbody>\r\n");
#nullable restore
#line 27 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlgorytmDobieraniaZasobowProdukcyjnych.Pages.ListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AlgorytmDobieraniaZasobowProdukcyjnych.Pages.ListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AlgorytmDobieraniaZasobowProdukcyjnych.Pages.ListModel>)PageContext?.ViewData;
        public AlgorytmDobieraniaZasobowProdukcyjnych.Pages.ListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
