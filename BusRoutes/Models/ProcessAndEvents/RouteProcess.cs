using BusRoutes.Models.NativeModels;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.ProcessAndEvents
{
    public class RouteProcess : IProcessModel
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        Route _route;
        public long Id
        {
            get
            {
                return _route.Id;
            }
            set
            {
                _route.Id = _route.Id;
            }
        }

        public string Name
        {
            get
            {
                return string.Format("{0} - {1}", _route.BeginStation.Name, _route.EndStation.Name);
            }
            set
            {

            }
        }

        public DateTime TimeStart
        {
            get
            {
                return _route.BeginStation.WaitedArrival;
            }
            set
            {
                _route.BeginStation.WaitedArrival = value;
            }
        }

        public DateTime TimeEnd
        {
            get
            {
                return _route.EndStation.WaitedArrival;
            }
            set
            {
                _route.EndStation.WaitedArrival = value;
            }
        }

        public string Description
        {
            get
            {
                return string.Format("Number of route -  {0}", _route.NumberOfRoute);
            }
            set
            {

            }
        }


        //операции над Events типа Add, Remove и т.д. не будут сохраняться
        public List<IEventModel> Events
        {
            get
            {
                return _route.Stations.Select(st => new StationEvent(st)).ToList<IEventModel>();
            }
            set
            {
                _route.Stations.Clear();
                foreach(var statEv in value.OfType<StationEvent>())
                {
                    statEv.AddToRoute(_route);
                }
                _route.Save();
            }
        }

        public RouteProcess(Route route)
        {
            _route = route;
        }

        public void Save(IProcessModel saveDataModel)
        {
            Id = saveDataModel.Id;
            Name = saveDataModel.Name;
            TimeStart = saveDataModel.TimeStart;
            TimeEnd = saveDataModel.TimeEnd;
            Description = saveDataModel.Description;
        }

        public void Update()
        {
            try
            {
                _route.Update();
                if (Updated != null)
                {
                    Updated(this, new ListModelEventArgs<IEventModel>(this));
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Update");
            }
        }

        public event EventHandler<ListModelEventArgs<IEventModel>> Updated;

        public void AddItems(IEnumerable<IItemModelAdapter<IEventModel>> addItems)
        {
            var addStationEvents = addItems.Select(itm => itm.DataModel).OfType<StationEvent>().ToList();
            var curStationEvents = Events.ToList();
            var addStationEventsId = addStationEvents.Select(stEv => stEv.Id).ToArray();
            var curStationEventsId = curStationEvents.Select(stEv => stEv.Id).ToArray();
            var nwStationEventsId = addStationEventsId.Except(curStationEventsId).ToArray();
            var nwStationEvents = addStationEvents.Where(stEv => nwStationEventsId.Contains(stEv.Id)).ToList();

            Events = curStationEvents.Union(nwStationEvents).ToList();
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<IEventModel>> remItems)
        {
            var remIds = remItems.Select(itm => itm.DataModel.Id).ToArray();
            var copyEvents = Events.ToList();
            copyEvents.RemoveAll(ev => remIds.Contains(ev.Id));
            Events = copyEvents;
        }

        public IEnumerable<IItemModelAdapter<IEventModel>> GetItems()
        {
            return Events.Select(ev => new ItemModelAdapterForPassive<IEventModel>(ev)).ToArray();
        }

    }
}
