#pragma checksum "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef94c1a427c959f2c6f10388d2658ed2bc058462"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AlgorytmDobieraniaZasobowProdukcyjnych.Pages.Shared.Pages_Shared__ModalImage), @"mvc.1.0.view", @"/Pages/Shared/_ModalImage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef94c1a427c959f2c6f10388d2658ed2bc058462", @"/Pages/Shared/_ModalImage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2c64e08beefb6cdbe0f52063262474da639500", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__ModalImage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlgorytmDobieraniaZasobowProdukcyjnych.Models.ImagePath>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml"
 if (Model.Path == "" && Model.Path2D == "")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3 class=\"alert-danger\">Najpierw wybierz narzędzie z tabeli</h3>\r\n");
#nullable restore
#line 7 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml"
}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label>Rysunek</label>\r\n    <br />\r\n    <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 268, "\"", 285, 1);
#nullable restore
#line 13 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml"
WriteAttributeValue("", 274, Model.Path, 274, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n");
            WriteLiteral("    <br />\r\n    <br />\r\n    <br />\r\n");
            WriteLiteral("    <label>Rysunek 2D</label>\r\n    <br />\r\n    <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 421, "\"", 440, 1);
#nullable restore
#line 21 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml"
WriteAttributeValue("", 427, Model.Path2D, 427, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n");
#nullable restore
#line 22 "C:\Users\Kuba\source\CSharp\AlgorytmDobieraniaZasobowProdukcyjnych\AlgorytmDobieraniaZasobowProdukcyjnych\Pages\Shared\_ModalImage.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlgorytmDobieraniaZasobowProdukcyjnych.Models.ImagePath> Html { get; private set; }
    }
}
#pragma warning restore 1591
