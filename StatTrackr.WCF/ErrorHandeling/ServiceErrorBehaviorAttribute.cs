using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace StatTrackr.WCF.ErrorHandeling
{
    public class ServiceErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;
        public ServiceErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }
        
        public void AddBindingParameters(ServiceDescription serviceDescription,
           System.ServiceModel.ServiceHostBase serviceHostBase,
           System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
           System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            System.ServiceModel.Dispatcher.IErrorHandler errorHandler;
            errorHandler = (System.ServiceModel.Dispatcher.IErrorHandler)Activator.CreateInstance(errorHandlerType);
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                cd.ErrorHandlers.Add(errorHandler);
            }
        }
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
    }
}
