#pragma checksum "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18bfe8b1c15e9884c657ab887cc6c40f8a383a20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
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
#line 1 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\_ViewImports.cshtml"
using BIED_research_suite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\_ViewImports.cshtml"
using BIED_research_suite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18bfe8b1c15e9884c657ab887cc6c40f8a383a20", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b5ab13fcf9c42032220070f637f9e047a8d967", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\_ViewStart.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

    if (User.IsInRole("Administrator"))
    {
        Layout = "~/Views/Shared/_LayoutAdministrator.cshtml";
    }


    if (User.IsInRole("Deelnemer"))
    {
        Layout = "~/Views/Shared/_LayoutParticipant.cshtml";
    }


    if (User.IsInRole("Onderzoeker"))
    {
        Layout = "~/Views/Shared/_LayoutResearcher.cshtml";
    }

#line default
#line hidden
#nullable disable
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