#pragma checksum "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8a608cda5d44144deeb5355569b2c7b7cd62fa6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SignUp), @"mvc.1.0.view", @"/Views/Home/SignUp.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/SignUp.cshtml", typeof(AspNetCore.Views_Home_SignUp))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8a608cda5d44144deeb5355569b2c7b7cd62fa6", @"/Views/Home/SignUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02771b3bf5c583f55fe47d163deb1c41c26a926", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SignUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company.Project.Web.Models.SIgnUpDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
  
    ViewData["Title"] = "SignUp";

#line default
#line hidden
#line 5 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
 if (TempData["message"] != null)
{

#line default
#line hidden
            BeginContext(129, 19, true);
            WriteLiteral("    <script>alert(\"");
            EndContext();
            BeginContext(149, 19, false);
#line 7 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
            EndContext();
            BeginContext(168, 14, true);
            WriteLiteral("\");</script>\r\n");
            EndContext();
#line 8 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
}

#line default
#line hidden
            BeginContext(185, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
 using (Html.BeginForm("SignUp", "Home", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{

#line default
#line hidden
            BeginContext(301, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(340, 69, false);
#line 13 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
   Write(Html.LabelFor(m => m.Name, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(409, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(457, 61, false);
#line 15 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(518, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(533, 74, false);
#line 16 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(607, 68, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(676, 70, false);
#line 20 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
   Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(746, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(794, 62, false);
#line 22 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(856, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(871, 75, false);
#line 23 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(946, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(978, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1017, 73, false);
#line 28 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
   Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1090, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(1138, 66, false);
#line 30 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1219, 78, false);
#line 31 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
       Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1297, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(1329, 188, true);
            WriteLiteral("    <div class=\"form-group mt-3\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <button type=\"submit\" class=\"btn btn-primary\">Sign Up</button>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 40 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\SignUp.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company.Project.Web.Models.SIgnUpDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
