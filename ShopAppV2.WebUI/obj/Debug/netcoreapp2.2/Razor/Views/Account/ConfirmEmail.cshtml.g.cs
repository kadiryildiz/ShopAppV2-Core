#pragma checksum "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4ac0977ec1f89d33e67cb870648c68f31e23fce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ConfirmEmail.cshtml", typeof(AspNetCore.Views_Account_ConfirmEmail))]
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
#line 1 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\_ViewImports.cshtml"
using ShopAppV2.Entities;

#line default
#line hidden
#line 2 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\_ViewImports.cshtml"
using ShopAppV2.WebUI.Extensions;

#line default
#line hidden
#line 3 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\_ViewImports.cshtml"
using ShopAppV2.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4ac0977ec1f89d33e67cb870648c68f31e23fce", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a79a5653e31b2fea7565dac0e91b89990af6d0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "ConfirmEmail";

#line default
#line hidden
            BeginContext(48, 71, true);
            WriteLiteral("\r\n<h1>Confirm Email</h1>\r\n<hr />\r\n\r\n<div class=\"alert alert-warning\">\r\n");
            EndContext();
#line 9 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\Account\ConfirmEmail.cshtml"
     if (TempData["message"] != null)
    {
        

#line default
#line hidden
            BeginContext(174, 19, false);
#line 11 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\Account\ConfirmEmail.cshtml"
   Write(TempData["message"]);

#line default
#line hidden
            EndContext();
#line 11 "C:\Users\kadir\source\repos\ShopAppV2\ShopAppV2.WebUI\Views\Account\ConfirmEmail.cshtml"
                            
    }

#line default
#line hidden
            BeginContext(202, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
