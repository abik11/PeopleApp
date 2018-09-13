using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace People.Service.Core.AutoMapper
{
   public sealed class AutomapServiceBehavior : Attribute, IServiceBehavior
   {
      public AutomapServiceBehavior()
      {
      }

      public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
          Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
      {
         AutomapperConfiguration.Configure();
      }

      public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
      {
      }

      public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
      {
      }
   }
}