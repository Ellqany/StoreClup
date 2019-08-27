using Domain.Entities;
using System;
using System.Text;
using System.Web.Mvc;

namespace WebGUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper Helper,
            PaginingInfo Pageinginfo, Func<int, string> pageurl)
        {
            StringBuilder Result = new StringBuilder();
            for (int i = 1; i <= Pageinginfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageurl(i));
                tag.InnerHtml = i.ToString();
                if (i == Pageinginfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                Result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(Result.ToString());
        }
    }
}