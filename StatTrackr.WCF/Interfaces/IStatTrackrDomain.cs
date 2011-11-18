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
        UriTemplate = "authenticate", Method = "POST")]        
        [OperationContract]
        string authenticate(string username, string password, string apikey);


        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "team/create", Method = "POST")]
        [OperationContract]
        string createteam(string token, Team team);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "team/update", Method = "POST")]
        [OperationContract]
        string updateteam(string token, Team team);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, UriTemplate = "team/all", Method = "POST")]
        [OperationContract]
        string getteams(string token);
       
    }
}
