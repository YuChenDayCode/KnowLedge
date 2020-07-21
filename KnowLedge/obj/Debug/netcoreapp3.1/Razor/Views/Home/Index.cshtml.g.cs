#pragma checksum "C:\Hello World\.NET\KnowLedge\KnowLedge\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3e5f40d38d7c8cbda2e77ffd3947a14d979cf10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3e5f40d38d7c8cbda2e77ffd3947a14d979cf10", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/lay/modules/layer.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/modules/layer/default/layer.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Hello World\.NET\KnowLedge\KnowLedge\Views\Home\Index.cshtml"
  
    Html.RenderPartial("_PartialIndex");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body {
        background-color: #efefef;
        line-height: 24px;
        font: 12px/1.5 'Microsoft Yahei', 'Simsun';
        color: #666666;
    }

    .item-list .layui-card {
        box-shadow: 0 2px 2px 1px rgba(0,0,0,.05);
    }

    .item-title {
        font-size: 18px;
        font-weight: 600;
        padding: 10px 0;
    }



    .summary {
        color: #999;
        margin: 4px 0;
    }

    .item-content {
        font-size: 15px;
        text-indent: 2em;
        margin: 10px 0 10px 0;
    }

    .view-all {
        margin-left: 4px;
        color: #175199;
    }

    .layui-btn-primary {
        border: none;
        background-color: #eee;
        /*color: #0084FF;*/
    }

    .item-bottom .layui-btn-sm {
        padding: 0 20px;
    }

    .layui-btn-primary .layui-btn .layui-icon {
        vertical-align: middle;
    }

    .item-bottom a {
        font-size: 1.2em;
        padding: 0 15px;
    }

    .article-main .typ");
            WriteLiteral(@"etag {
        font-size: 16px;
        font-weight: bold;
        line-height: 36px;
        color: #333;
        border-bottom: #db6d4c 4px solid;
    }

    .question-content {
        font-size: 14px;
    }
</style>


<div class=""layui-container container"" id=""warp"">
    <div class=""layui-row layui-col-space10"">
        <a>");
#nullable restore
#line 75 "C:\Hello World\.NET\KnowLedge\KnowLedge\Views\Home\Index.cshtml"
      Write(ViewBag.Aa);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
        <div class=""layui-col-md8"" style=""padding-right: 16px"">
            <div class=""article-main"">
                <div v-for=""(item,index) in list"" style=""padding: 0px 0px; background: #fff; margin-top: 10px"">
                    <div class=""layui-card"">
                        <div class=""layui-card-body"">
                            <div class=""caption-subject uppercase"" style=""font-size: 18px; color: #444; font-weight: 600;"">
                                <h2>
                                    <a :href=""'/Answer/Index/'+item.id"" :title=""item.name"" target=""_blank"" style=""font-size: 18px; color: #445; font-weight: 600;"">{{item.title}}</a>
                                </h2>
                            </div>
                            <p style=""margin:15px 0 10px 0"">
                                <a href=""/user/15985459135"" target=""_blank"">
                                    <img src=""https://img.tnblog.net/userdata/minheads/min_73a057e6dcca4c539347788275ae3076.jpeg"" style=""w");
            WriteLiteral(@"idth:22px;height:22px;border-radius:30%;margin-top:-4px"">
                                </a>
                                <span class="" f_r"" style=""padding-left: 4px""><b><a href=""https://www.tnblog.net/user/15985459135"" target=""_blank"">雨辰</a></b></span>
                            </p>
                            <div style=""margin: 10px 0 10px 0; font-size: 14px;text-indent:2em;"">
                                <a href=""#""> {{item.desc}}</a>
                            </div>
                            <p class=""autor"">
                                <button class=""layui-btn layui-btn-sm layui-btn-primary"">
                                    <i class=""layui-icon layui-icon-praise"" style=""vertical-align: middle;""></i>
                                    <a style=""font-size: 1.10em;"">10</a>
                                </button>
                                <span class=""viewnum f_r"">回答(<a href=""#"">7</a>)</span>
                                <span class=""viewnum f_r"">浏览(<a href=""#""");
            WriteLiteral(@">{{item.views}}</a>)</span>
                                <span class=""lm f_l""><a v-for=""ctag in tagSplit(item.tag)"" :href=""'/Tag/Index/'+ctag"" target=""_blank"">{{ctag}} </a></span>
                                <span class=""dtime f_l"" :title=""'提问时间:'+item.createTime"">{{item.createTime}}</span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""layui-col-md4"" id=""crightdiv"" style=""position: static;"">

            <div class=""layui-form-item"">
                <button id=""Search_Btn"" ");
            WriteLiteral("@click=\"ShowLayer()\" data-method=\"offset\" data-type=\"auto\" class=\"layui-btn layui-btn-fluid layui-btn-normal\">我要提问</button>\r\n                <div class=\"layui-btn-group\">\r\n");
            WriteLiteral(@"                </div>
            </div>

            <div class=""cloud"">
                <h3 style=""margin-top: 10px"">问答标签</h3>
                <ul>
                    <li><a href=""/Nav/1"">.NET</a></li>
                    <li><a href=""/Nav/2"">.NET Core</a></li>
                    <li><a href=""/Nav/3"">.NET MVC</a></li>
                    <li><a href=""/Nav/5"">JAVA</a></li>
                    <li><a href=""/Nav/7"">消息队列</a></li>
                    <li><a href=""/Nav/8"">Python</a></li>
                    <li><a href=""/Nav/12"">数据库</a></li>
                    <li><a href=""/Nav/13"">缓存</a></li>
                    <li><a href=""/Nav/18"">云服务</a></li>
                    <li><a href=""/Nav/19"">架构</a></li>
                    <li><a href=""/Nav/20"">Linux</a></li>
                    <li><a href=""/Nav/21"">微信</a></li>
                    <li><a href=""/Nav/22"">随笔</a></li>
                    <li><a href=""/Nav/Other"">其他</a></li>
                </ul>
            </div>


        </div>
    </div");
            WriteLiteral(">\r\n\r\n\r\n    <div id=\"question\" style=\"display:none;padding:15px;\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3e5f40d38d7c8cbda2e77ffd3947a14d979cf1010135", async() => {
                WriteLiteral(@"
            <div class=""question-content"">
                <div class=""layui-form-item"">
                    <input type=""text"" name=""title"" v-model=""question.title"" lay-verify=""required"" placeholder=""请输入问题标题"" autocomplete=""off"" class=""layui-input"">
                </div>
                <div class=""layui-form-item"">
                    <textarea placeholder=""请输入问题描述"" class=""layui-textarea"" v-model=""question.desc""></textarea>
                </div>
                <div class=""layui-form-item"">
                    <input type=""text"" name=""title"" required lay-verify=""required"" placeholder=""问题分类(逗号隔开)"" autocomplete=""off"" class=""layui-input"" v-model=""question.tag"">
                </div>
                <div class=""layui-input-block"" style=""float:right"">
                    <button type=""button"" class=""layui-btn layui-btn-normal"" ");
                WriteLiteral("@click=\"Askquestion()\">发布问题</button>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3e5f40d38d7c8cbda2e77ffd3947a14d979cf1012536", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3e5f40d38d7c8cbda2e77ffd3947a14d979cf1013636", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"">
    new Vue({
        el: ""#warp"",
        data: {
            question: {},//{ tagId: ""1,2,3"", desc: ""1231233"", title: ""name"" },
                list: []
                //{ ""id"": 1, ""name"": ""oracle数据库表dual的讲解"", ""desc"": ""我希望有个如你一般的人我还是很喜欢你，像日光洒满天地，温柔惬意。先提个问 ：oracle数据库里dual表是什么表？..."", author: ""陪你听风"", createtime: ""2020-06-05"", fromtag: ""其他"" },
                //{ ""id"": 2, ""name"": ""屏幕截图1"", ""desc"": ""icPick 是一款优秀的免费屏幕截图工具"", author: ""雨辰"", createtime: ""2019-9-16 17:24:50"", fromtag: ""其他"" },
                //{ ""id"": 3, ""name"": ""屏幕截图2"", ""desc"": ""icPick 是一款优秀的免费屏幕截图工具"", author: ""雨辰"", createtime: ""2019-9-16 17:24:50"", fromtag: ""其他"" }]

            },
            mounted() {
                this.InitData();
            },
            computed: {
                tagSplit: function () {
                    return function (tag) {
                        return (tag || """").split("","");
                    }
                }
            },
            methods: {
  ");
                WriteLiteral(@"              InitData: function () {
                      let that = this;
                    $.get('/Home/GetQuestion', {}, function (data) {
                        console.log(data);
                        that.list = data;
                    });
                },
                ShowLayer: function () {
                    var layer = layui.layer;
                    layer.open({
                        type: 1,
                        title: false,
                        resize: false,
                        area: ['450', '300'],
                        offset: '200px',
                        content: $('#question')
                    });
                },
                Askquestion: function () {
                    $.post('");
#nullable restore
#line 212 "C:\Hello World\.NET\KnowLedge\KnowLedge\Views\Home\Index.cshtml"
                       Write(Url.Action("Ask"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', this.question, function (data) {
                        console.log(data);
                        if (data.Status) {
                            location.reload(true);
                        }
                    });

                }
            }
        });


        $(function () {
            $(""#bdcsMain"").keyup(function () {
                if (event.keyCode == 13) {
                    //触发搜索按钮,就不用就封装方法了
                    $(""#searchbut"").click();
                }
            });

        });
    </script>

");
            }
            );
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
