using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BkG.Routing
{
    public class RouteTemplateRoutingConvention : IApplicationModelConvention
    {
        public RouteTemplateRoutingConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            if(null == routeTemplateProvider)
            {
                throw new ArgumentNullException(nameof(routeTemplateProvider), "The route attribute must be provided.");
            }

            _attributeRouteModel = new AttributeRouteModel(routeTemplateProvider);
        }

        public void Apply(ApplicationModel application)
        {
            if(null == application)
            {
                return;
            }

            var vSelectors = application
                                .Controllers
                                .SelectMany(controller => controller.Selectors);

            foreach (var vSelector in vSelectors)
            {
                vSelector.AttributeRouteModel = 
                                null == vSelector.AttributeRouteModel
                                    ? _attributeRouteModel
                                    : AttributeRouteModel
                                        .CombineAttributeRouteModel(_attributeRouteModel, vSelector.AttributeRouteModel);
            }
        }

        private readonly AttributeRouteModel _attributeRouteModel;
    }
}