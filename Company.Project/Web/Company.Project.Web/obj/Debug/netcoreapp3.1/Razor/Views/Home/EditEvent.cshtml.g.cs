#pragma checksum "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7875b1c3cc67e055c6c9da3332e563ea14d9eee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditEvent), @"mvc.1.0.view", @"/Views/Home/EditEvent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/EditEvent.cshtml", typeof(AspNetCore.Views_Home_EditEvent))]
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
#line 1 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web;

#line default
#line hidden
#line 2 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7875b1c3cc67e055c6c9da3332e563ea14d9eee", @"/Views/Home/EditEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02771b3bf5c583f55fe47d163deb1c41c26a926", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company.Project.Web.Models.EventTitles>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 37, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(84, 209, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7875b1c3cc67e055c6c9da3332e563ea14d9eee3624", async() => {
                BeginContext(90, 196, true);
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Event Form</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(293, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(295, 3523, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7875b1c3cc67e055c6c9da3332e563ea14d9eee5019", async() => {
                BeginContext(301, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 12 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
     if (TempData["message"] != null)
    {

#line default
#line hidden
                BeginContext(349, 23, true);
                WriteLiteral("        <script>alert(\"");
                EndContext();
                BeginContext(373, 19, false);
#line 14 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                  Write(TempData["message"]);

#line default
#line hidden
                EndContext();
                BeginContext(392, 14, true);
                WriteLiteral("\");</script>\r\n");
                EndContext();
#line 15 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
    }

#line default
#line hidden
                BeginContext(413, 147, true);
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8 col-md-offset-2\">\r\n                <h2>Event Form</h2>\r\n");
                EndContext();
#line 21 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                 using (Html.BeginForm("EditEvent", "Home"))
                {

#line default
#line hidden
                BeginContext(641, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(712, 27, false);
#line 24 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.title));

#line default
#line hidden
                EndContext();
                BeginContext(739, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(766, 75, false);
#line 25 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextBoxFor(m => m.title, Model.title, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(841, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(873, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(944, 26, false);
#line 29 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.date));

#line default
#line hidden
                EndContext();
                BeginContext(970, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(997, 94, false);
#line 30 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextBoxFor(m => m.date, "{0:yyyy-MM-dd}", new { type = "date", @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(1091, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(1123, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(1194, 30, false);
#line 34 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.location));

#line default
#line hidden
                EndContext();
                BeginContext(1224, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1251, 65, false);
#line 35 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextBoxFor(m => m.location, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(1316, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(1348, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(1419, 31, false);
#line 39 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.startTime));

#line default
#line hidden
                EndContext();
                BeginContext(1450, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1477, 388, false);
#line 40 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.DropDownList("StartTime", new SelectList(new List<string> { "00:00 AM", "01:00 AM", "02:00 AM", "03:00 AM", "04:00 AM", "05:00 AM", "06:00 AM", "07:00 AM", "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "13:00 PM", "14:00 PM", "15:00 PM", "16:00 PM", "17:00 PM", "18:00 PM", "19:00 PM", "20:00 PM", "21:00 PM", "22:00 PM", "23:00 PM" }), new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(1865, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(1897, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(1968, 26, false);
#line 44 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.type));

#line default
#line hidden
                EndContext();
                BeginContext(1994, 116, true);
                WriteLiteral("\r\n                        <div class=\"radio\">\r\n                            <label>\r\n                                ");
                EndContext();
                BeginContext(2111, 64, false);
#line 47 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                           Write(Html.RadioButtonFor(m => m.type, true, new { @class = "radio" }));

#line default
#line hidden
                EndContext();
                BeginContext(2175, 226, true);
                WriteLiteral("\r\n                                Public\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"radio\">\r\n                            <label>\r\n                                ");
                EndContext();
                BeginContext(2402, 65, false);
#line 53 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                           Write(Html.RadioButtonFor(m => m.type, false, new { @class = "radio" }));

#line default
#line hidden
                EndContext();
                BeginContext(2467, 141, true);
                WriteLiteral("\r\n                                Private\r\n                            </label>\r\n                        </div>\r\n                    </div>\r\n");
                EndContext();
                BeginContext(2610, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(2681, 30, false);
#line 60 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.duration));

#line default
#line hidden
                EndContext();
                BeginContext(2711, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2738, 65, false);
#line 61 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextBoxFor(m => m.duration, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(2803, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(2835, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(2906, 33, false);
#line 65 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.description));

#line default
#line hidden
                EndContext();
                BeginContext(2939, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2966, 81, false);
#line 66 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextAreaFor(m => m.description, new { @class = "form-control", rows = "5" }));

#line default
#line hidden
                EndContext();
                BeginContext(3047, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(3079, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(3150, 34, false);
#line 70 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.otherDetails));

#line default
#line hidden
                EndContext();
                BeginContext(3184, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(3211, 82, false);
#line 71 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextAreaFor(m => m.otherDetails, new { @class = "form-control", rows = "5" }));

#line default
#line hidden
                EndContext();
                BeginContext(3293, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(3325, 70, true);
                WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
                EndContext();
                BeginContext(3396, 35, false);
#line 75 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.LabelFor(m => m.inviteByEmail));

#line default
#line hidden
                EndContext();
                BeginContext(3431, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(3458, 70, false);
#line 76 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                   Write(Html.TextBoxFor(m => m.inviteByEmail, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(3528, 30, true);
                WriteLiteral("\r\n                    </div>\r\n");
                EndContext();
                BeginContext(3581, 29, false);
#line 79 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
               Write(Html.HiddenFor(m => m.userId));

#line default
#line hidden
                EndContext();
                BeginContext(3633, 25, false);
#line 80 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
               Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
                EndContext();
                BeginContext(3662, 82, true);
                WriteLiteral("                    <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n");
                EndContext();
#line 83 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\EditEvent.cshtml"
                }

#line default
#line hidden
                BeginContext(3763, 48, true);
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3818, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company.Project.Web.Models.EventTitles> Html { get; private set; }
    }
}
#pragma warning restore 1591
