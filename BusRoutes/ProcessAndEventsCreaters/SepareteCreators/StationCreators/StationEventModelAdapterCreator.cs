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

namespace BusRoutes.ProcessAndEventsCreaters.SepareteCreators.StationCreators
{
    public class StationEventModelAdapterCreator
        : EventModelAdapterCreator
    {
        public override IEventModel CreateNewDataModel()
        {
            Station nwStation = new Station(0, 0, "Unknown", DateTime.Now, null, "Unknown");
            //nwStation.Save();
            StationEvent nwStationEvent = new StationEvent(nwStation);
            return nwStationEvent;
        }

        public override IItemModelAdapter<IEventModel> CreateDeepCopyOfItemModel(IItemModelAdapter<IEventModel> model)
        {
            StationEvent stationEvent = (StationEvent)model.DataModel;
            var deepCopy = stationEvent.Copy();
            var newModel = new ItemModelAdapterForPassive<IEventModel>(deepCopy);
            return newModel;
        }
    }
}
