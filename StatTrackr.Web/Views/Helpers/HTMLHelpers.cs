using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework.Service;

namespace MvcHtmlHelpers
{
    public static class HTMLHelpers
    {
        static string selectedClass = "class=\"active iconed\"";

        public static MvcHtmlString SelectedNavItem(this HtmlHelper helper, string page1, string page2)
        {
            if ( !string.IsNullOrEmpty(page1) && !string.IsNullOrEmpty(page2) && page1.Equals(page2))
                return new MvcHtmlString(selectedClass);
            else
                return new MvcHtmlString(string.Empty);
        }

        public static MvcHtmlString RenderNavigationDropdown(this HtmlHelper helper, Navigation navigationObj, string dropdown)
        {
            string rtnString = string.Empty;

            if (navigationObj != null)
            {
                switch (dropdown)
                {
                    case "leagues":
                        rtnString = getLeagueDropdown(navigationObj.leagues);
                        break;
                    case "divisions":
                        rtnString = getDivisionDropdown(navigationObj.divisions);
                        break;
                    case "teams":
                        rtnString = getTeamsDropdown(navigationObj.teams);
                        break;
                    default:
                        // return nothing
                        break;
                }
            }

            return new MvcHtmlString(rtnString);
        }

        private static string getTeamsDropdown(List<Team> teams)
        {
            string rtnString = string.Empty;

            if (teams != null && teams.Count > 0)
            {
                rtnString += "<ul>";

                foreach (Team t in teams)
                {
                    rtnString += "<li><a href=\"/team/edit/" + t.TeamID + "\">" + t.TeamName + "</a></li>";
                }

                rtnString += "</ul>";
            }

            return rtnString;
        }

        private static string getDivisionDropdown(List<Division> divisions)
        {
            string rtnString = string.Empty;

            if (divisions != null && divisions.Count > 0)
            {
                rtnString += "<ul>";

                foreach (Division d in divisions)
                {
                    rtnString += "<li><a href=\"/division/edit/" + d.DivisionID + "\">" + d.Name + "</a></li>";
                }

                rtnString += "</ul>";
            }

            return rtnString;
        }

        private static string getLeagueDropdown(List<League> leagues)
        {
            string rtnString = string.Empty;
            
            if (leagues != null && leagues.Count > 0)
            {
                rtnString += "<ul>";

                foreach (League l in leagues)
                {
                    rtnString += "<li><a href=\"/league/edit/" + l.LeagueID + "\">" + l.Name + "</a></li>";
                }

                rtnString += "</ul>";
            }

            return rtnString;
        }
    }
}