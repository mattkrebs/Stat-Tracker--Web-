using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.WCF.ErrorHandeling;
using System.ServiceModel.Activation;
using StatTrackr.WCF.Interfaces;
using StatTrackr.Core;



namespace StatTrackr.WCF
{
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StatTrackrServiceBase : IStatTrackrDomain
    {


        #region IStatTrackrDomain Members

        public string authenticate(string username, string password, string apikey)
        {
            return UserService.Login(username, password, apikey);
        }

        #endregion

        private string ServiceError(string message)
        {
            
            return String.Format("{ \"errorMessage\" : \"{0}\"}", message);
        }

      
    }
}
