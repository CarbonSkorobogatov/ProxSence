using System;
using System.Text;
using System.Web.Mvc;
using ProxSenceWebProj.Models;

namespace ProxSenceWebProj.SiteHH
{
    public static class PageBreak
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageBreakModel pageBreakModel,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageBreakModel.AllPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageBreakModel.Page)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-warning");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

                return MvcHtmlString.Create(result.ToString());
        }

    }
}