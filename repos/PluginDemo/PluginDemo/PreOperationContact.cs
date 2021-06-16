using System;
using Microsoft.Xrm.Sdk;

namespace PluginsDemo
{
    public class PreOperationContact : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)
                serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (context.MessageName != "Create")
                return;

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
               
                Entity contact = (Entity)context.InputParameters["Target"];

               
                if (contact.LogicalName != "contact")
                    return;

                
                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                try
                {
                    if (context.Stage == 20) {
                        if (contact.Attributes["mobilephone"] != null && contact.Attributes["mobilephone"].ToString().Substring(0, 2) == "05")
                        {
                        Entity textMessage = new Entity("el_text_message");
                        textMessage.Attributes["name"] = "textMessageExample";
                        textMessage.Attributes["el_id_contact"] = new EntityReference("contact", new Guid(contact.Id.ToString()));
                        service.Create(textMessage);
                        }
                        else
                        {
                            string exceptionMessage = "נא להזין טלפון נייד";
                            throw new InvalidPluginExecutionException(exceptionMessage);
                        } 
                    }
                }

                catch (Exception ex)
                {
                    tracingService.Trace("An error has occured" + ex.Message);
                    throw;
                }
            }
        }
    }
}