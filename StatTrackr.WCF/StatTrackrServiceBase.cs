using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.WCF.ErrorHandeling;
using System.ServiceModel.Activation;
using StatTrackr.WCF.Interfaces;

namespace StatTrackr.WCF
{
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StatTrackrServiceBase : IStatTrackrDomain
    {


        public string hello()
        {
            return "Yes I am hear, leave me alone : " + DateTime.Now.ToString();
        }

    }
}
