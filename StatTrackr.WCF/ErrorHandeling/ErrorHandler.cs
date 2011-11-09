using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTrackr.WCF.ErrorHandeling
{
    public class ErrorHandler : System.ServiceModel.Dispatcher.IErrorHandler
    {
        #region IErrorHandler Members
        public bool HandleError(Exception error)
        {
           // Elmah.ErrorSignal.FromCurrentContext().Raise(error);
            return false;
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error == null)
                return;
            //if (HttpContext.Current == null) //In case we run outside of IIS
            //    return;
            //Elmah.ErrorSignal.FromCurrentContext().Raise(error);
        }
        #endregion
    }
}
