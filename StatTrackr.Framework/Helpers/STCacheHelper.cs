using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Service;
using StatTrackr.Framework.Domain;
using System.Runtime.Caching;
using StatTrackr.Framework.Security;

namespace StatTrackr.Framework.Helpers
{
    
    public static class STCacheHelper
    {

        static readonly ObjectCache Cache = MemoryCache.Default;
        static readonly string NavigationKeyString = "navigation";

        /*
         * Method to return an object from the Cache given a key.
         * 
         * Returns Null if not found
         */
        public static T GetFromCache<T>(string key) where T : class
        {
            try
            {
                return (T)Cache[key];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /*
         * Adds an object to the Cache with the given key
         */
        public static void AddToCache(object objToAdd, string key)
        {
            AddToCache(objToAdd, key, 10);
        }

        /*
         * Adds an object to the Cache with the given key for a duration passed in, in minutes
         */
        public static void AddToCache(object objToAdd, string key, int minutes)
        {
            Cache.Add(key, objToAdd, DateTime.Now.AddMinutes(minutes));
        }

        /*
         * Clears Navigation Cache for a given user
         */
        public static void ClearNavigationCacheForUser(Guid userId)
        {
            ClearCacheKey(userId + NavigationKeyString);
        }

        /*
         * Clears Navigation Cache for the current logged in user
         */
        public static void ClearNavigationCacheForCurrentUser()
        {
            if (CodeFirstSecurity.IsAuthenticated)
            {
                ClearCacheKey(CodeFirstSecurity.CurrentUserId + NavigationKeyString);
            }
        }

        /*
         * Clears The cache based on a given Key
         */
        public static void ClearCacheKey(string key)
        {
            Cache.Remove(key);
        }

        /*
         * Returns the Navigation object for a given User ID
         * 
         * Will check the Cache first to check if it is there is Cache is enabled.
         */
        public static Navigation GetNavigationByUserId(Guid user)
        {
            string key = user + NavigationKeyString;
            Navigation rtnNavigation = null;
            
            if( STConfig.UseCache )
                rtnNavigation = GetFromCache<Navigation>(key);

            if (rtnNavigation == null)
            {
                rtnNavigation = new Navigation();
                rtnNavigation.divisions = Division.GetAllDivisionsByCurrentUser();
                rtnNavigation.teams = Team.GetAllTeamsByCurrentUser();
                rtnNavigation.leagues = League.GetAllLeaguesByCurrentUser();

                AddToCache(rtnNavigation, key, 10);
            }

            return rtnNavigation;
        }

        /*
         * This will return the Navigation for the CurrentUser logged in
         */
        public static Navigation GetNavigationByCurrentUser()
        {
            if (CodeFirstSecurity.IsAuthenticated)
            {
                return GetNavigationByUserId(CodeFirstSecurity.CurrentUserId);
            }
            else
            {
                return null;
            }
        }

    }

}
