using System;
using System.Web.Mvc;

namespace Messages.Web.Navigation
{
    // http://weblogs.asp.net/imranbaloch/a-simple-bootstrap-pager-html-helper
    public static class HtmlHelperExtensions
    {

        public static MvcHtmlString BootstrapPager(this HtmlHelper helper, int page, Func<int, string> action, int totalItems, int pageSize = 10, int numberOfLinks = 5)
        {
            if (totalItems <= 0)
            {
                return MvcHtmlString.Empty;
            }

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var lastPageNumber = (int)Math.Ceiling((double)page / numberOfLinks) * numberOfLinks;
            var firstPageNumber = lastPageNumber - (numberOfLinks - 1);
            var hasPreviousPage = page > 1;
            var hasNextPage = page < totalPages;
            if (lastPageNumber > totalPages)
            {
                lastPageNumber = totalPages;
            }
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul.InnerHtml += AddLink(1, action, page == 1, "disabled", "<<", "First Page");
            ul.InnerHtml += AddLink(page - 1, action, !hasPreviousPage, "disabled", "<", "Previous Page");

            for (int i = firstPageNumber; i <= lastPageNumber; i++)
            {
                ul.InnerHtml += AddLink(i, action, i == page, "active", i.ToString(), i.ToString());

            }
            ul.InnerHtml += AddLink(page + 1, action, !hasNextPage, "disabled", ">", "Next Page");
            ul.InnerHtml += AddLink(totalPages, action, page == totalPages, "disabled", ">>", "Last Page");
            return MvcHtmlString.Create(ul.ToString());
        }



        private static TagBuilder AddLink(int index, Func<int, string> action, bool condition, string classToAdd, string linkText, string tooltip)
        {
            var li = new TagBuilder("li");
            li.MergeAttribute("title", tooltip);
            if (condition)
            {
                li.AddCssClass(classToAdd);
            }
            var a = new TagBuilder("a");
            a.MergeAttribute("href", !condition ? action(index) : "javascript:");
            a.SetInnerText(linkText);
            li.InnerHtml = a.ToString();
            return li;
        }
    }
}