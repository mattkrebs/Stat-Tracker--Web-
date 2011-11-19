using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHtmlHelpers
{
    public static class HTMLHelpers
    {
        static string selectedClass = "class=\"active iconed\"";

        public static MvcHtmlString SelectedNavItem(this HtmlHelper helper, string page1, string page2)
        {

            if (page1.Equals(page2))
                return new MvcHtmlString(selectedClass);
            else
                return new MvcHtmlString(string.Empty);
        }
    }
}