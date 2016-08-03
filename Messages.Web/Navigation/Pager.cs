using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Web.Navigation
{
    public class Pager
    {
        public const int PageDefault = 1;

        public Pager(PagerParameters pagerParameters)
        {
            Page = pagerParameters.Page.HasValue && pagerParameters.Page.Value > 0
                ? pagerParameters.Page.Value
                : PageDefault;

            // TODO: get it from settings
            PageSize = 4; 
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}