using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Framework.Helpers
{
    public static class STConfig
    {

        private static bool GetConfigValue(string key, bool defaultVal)
        {
            string val = System.Web.Configuration.WebConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(val))
            {
                return defaultVal;
            }
            else
            {
                return "true".Equals(val.ToLower());
            }
        }

        private static string GetConfigValue(string key, string defaultVal)
        {
            string val = System.Web.Configuration.WebConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(val) ? defaultVal : val;
        }

        private static int GetConfigValue(string key, int defaultVal)
        {
            string val = System.Web.Configuration.WebConfigurationManager.AppSettings[key];
            int rtnInt = defaultVal;

            if (!string.IsNullOrEmpty(val))
            {
                try
                {
                    rtnInt = Int32.Parse(val);
                }
                catch (Exception e)
                {
                    rtnInt = defaultVal;
                }
            }

            return rtnInt;
        }

        public static bool UseCache
        {
            get
            {
                return GetConfigValue("UseCache", true);
            }
        }

    }
}
