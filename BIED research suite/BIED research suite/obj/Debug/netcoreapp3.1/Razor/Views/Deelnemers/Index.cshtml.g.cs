#pragma checksum "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75a87b75ec9684daa04a804c74655caf85ba9c1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Deelnemers_Index), @"mvc.1.0.view", @"/Views/Deelnemers/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a87b75ec9684daa04a804c74655caf85ba9c1a", @"/Views/Deelnemers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b5ab13fcf9c42032220070f637f9e047a8d967", @"/Views/_ViewImports.cshtml")]
    public class Views_Deelnemers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BIED_research_suite.Models.Database_entities.Questionnaire>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml"
  
    ViewData["Title"] = "Mijn vragenlijsten";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Openstaande vragenlijsten</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Vragenlijst
            </th>
            <th>
                Start datum
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml"
 foreach (var questionnaire in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 25 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml"
           Write(Html.DisplayFor(model => questionnaire.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75a87b75ec9684daa04a804c74655caf85ba9c1a5259", async() => {
                WriteLiteral("Invullen");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml"
                                       WriteLiteral(questionnaire.QuestionnaireID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 34 "D:\SynologyDrive\Programming\Projects (language independent)\All purpose data collector\Code\BIED_research_suite\BIED research suite\BIED research suite\Views\Deelnemers\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BIED_research_suite.Models.Database_entities.Questionnaire>> Html { get; private set; }
    }
}
#pragma warning restore 1591
