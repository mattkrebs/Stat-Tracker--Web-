using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using StatTrackr.Framework.Domain;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace StatTrackr.WCF.Interfaces
{
    [ServiceContract]
    public interface IStatTrackrDomain
    {

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "authenticate")]        
        [OperationContract]
        string authenticate(string username, string password, string apikey);


    

    }
}
