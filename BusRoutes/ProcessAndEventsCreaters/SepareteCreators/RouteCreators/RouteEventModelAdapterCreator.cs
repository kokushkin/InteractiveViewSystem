using BusRoutes.Models.NativeModels;
using BusRoutes.Models.ProcessAndEvents;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.ProcessAndEventsCreaters.SepareteCreators.RouteCreators
{
    public class RouteEventModelAdapterCreator
        : EventModelAdapterCreator
    {
        public override IEventModel CreateNewDataModel()
        {
            Route nwRoute = new Route(0, 0, null, null);
            RouteEvent nwRouteEvent = new RouteEvent(nwRoute);
            return nwRouteEvent;
        }

        public override IItemModelAdapter<IEventModel> CreateDeepCopyOfItemModel(IItemModelAdapter<IEventModel> model)
        {
            RouteEvent routeEvent = (RouteEvent)model.DataModel;
            var deepCopy = routeEvent.Copy();
            var newModel = new ItemModelAdapterForPassive<IEventModel>(deepCopy);
            return newModel;
        }
    }
}
