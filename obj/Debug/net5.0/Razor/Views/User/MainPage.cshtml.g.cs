#pragma checksum "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffa1ed5ed29675f46f8984d17bb1b20151c3e726"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_MainPage), @"mvc.1.0.view", @"/Views/User/MainPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffa1ed5ed29675f46f8984d17bb1b20151c3e726", @"/Views/User/MainPage.cshtml")]
    public class Views_User_MainPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HRService.ViewModels.EmployeeListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""MainPageContent"">
    <h1 class=""text-center text-info"">Employee List</h1>
    <div>
        <form action=""/User/AddEmployeePage"" method=""get"">
            <button type=""submit"" class=""btn btn-outline-success"">Add Employee</button>
        </form>
    </div>

    <div id=""SearchBar"">
        <form action=""/User/MainPage"" method=""get"">
            <input type=""search"" placeholder=""Search..."" name=""searchContent"" id=""searchContent""/>
            <button type=""submit"" id=""searchBtn"" class=""btn btn-sm btn-outline-info"">&#128269;</button>
        </form>
    </div>

");
#nullable restore
#line 21 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
     if(TempData["info"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p> ");
#nullable restore
#line 23 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
       Write(TempData["info"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        <form action=\"/User/ResetSearch\" method=\"get\">\r\n            <button type=\"submit\" style=\"background: none; border: none;\"> reset search </button>\r\n        </form>\r\n");
#nullable restore
#line 27 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"EmployeeList\">\r\n        <ol>\r\n");
#nullable restore
#line 31 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                <p style=\"display:inline-block;\"> ");
#nullable restore
#line 34 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
                                             Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
                                                             Write(item.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                <form action=\"/User/EditEmployee\" method=\"post\" style=\"display:inline-block\">\r\n                    <input");
            BeginWriteAttribute("value", " value=\"", 1304, "\"", 1320, 1);
#nullable restore
#line 37 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
WriteAttributeValue("", 1312, item.Id, 1312, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"employeeId\" style=\"display: none\" />\r\n                    <button type=\"submit\" class=\"btn btn-outline-warning\">Edit</button>\r\n\r\n                </form>\r\n\r\n                <button class=\"modal-title btn btn-outline-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1550, "\"", 1579, 3);
            WriteAttributeValue("", 1560, "OpenModal(", 1560, 10, true);
#nullable restore
#line 42 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
WriteAttributeValue("", 1570, item.Id, 1570, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1578, ")", 1578, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"openModalBtn\">Delete</button>\r\n\r\n\r\n            </li>\r\n");
#nullable restore
#line 46 "D:\Visual Studio 2019\projects\HRService\Views\User\MainPage.cshtml"
           
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </ol>
    </div>

    <div class=""modal"" id=""modal"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <p> Are you sure you want to delete this employee? </p>
            </div>
            <div class=""modal-body"">              
                <div id=""modalBody"">
                    <form style=""display: inline-block"">
                        <button id=""deleteEmployeeBtn"" name=""Id"" type=""button"" class=""btn btn-danger""> Yes </button>
                    </form>

                    <button id=""closeModal"" type=""button"" class=""btn btn-success""> No </button>

                </div>

            </div>
        </div>


    </div>

    <div id=""LogOut"">
        <form action=""/User/LogOut"" method=""get"">
            <button type=""submit"" class=""btn btn-dark"">Log Out</button>
        </form>
    </div>
</div>


<script>
    var modal = document.getElementById('modal');

    $('#openModalBtn').click(function () {
        debugger
");
            WriteLiteral(@"        OpenModal();
    });
    function OpenModal(input) {
        modal.style.display = ""block"";
        $('#deleteEmployeeBtn').val(input);
    }

    $('#closeModal').click(function () {
        modal.style.display = ""none"";
    });

</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HRService.ViewModels.EmployeeListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
