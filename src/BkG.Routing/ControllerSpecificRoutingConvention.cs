using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BkG.Routing
{
    public class ControllerSpecificRoutingConvention : IApplicationModelConvention
    {
        public ControllerSpecificRoutingConvention(Func<ControllerModel, AttributeRouteModel> attributeFunction)
        {
            if(null == attributeFunction)
            {
                throw new ArgumentNullException(nameof(attributeFunction), "A valid attribute mapping function is required");
            }

            _mappingFunction = attributeFunction;
        }

        public void Apply(ApplicationModel application)
        {
            if(null == application)
            {
                return;
            }

            foreach(var vController in application.Controllers)
            {
                var vAttributeRouteModel = _mappingFunction(vController);

                foreach (var vSelector in vController.Selectors)
                {
                    vSelector.AttributeRouteModel = 
                                    null == vSelector.AttributeRouteModel
                                        ? vAttributeRouteModel
                                        : AttributeRouteModel
                                            .CombineAttributeRouteModel(vAttributeRouteModel, vSelector.AttributeRouteModel);
                }
            }
        }
    
        private readonly Func<ControllerModel, AttributeRouteModel> _mappingFunction;
    }
}