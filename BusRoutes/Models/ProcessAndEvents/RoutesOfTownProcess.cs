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
    public class RoutesOfTownProcess : IProcessModel
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        RoutesOfTown _townRoutes;

        public long Id { get; set; }

        public string Name
        {
            get
            {
                return _townRoutes.Name;
            }
            set
            {
                _townRoutes.Name = value;
            }
        }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Description
        {
            get
            {
                return string.Format("Total {0} routes", _townRoutes.NumberOfRoutes);
            }
            set
            {

            }
        }

        public List<IEventModel> Events
        {
            get
            {
                return _townRoutes.Routes.Select(rt => new RouteEvent(rt)).ToList<IEventModel>();
            }
            set
            {
                _townRoutes.Routes.Clear();
                foreach (var routEv in value.OfType<RouteEvent>())
                {
                    routEv.AddToRoute(_townRoutes);
                }
                _townRoutes.Save();
            }
        }

        public RoutesOfTownProcess(RoutesOfTown townRoutes)
        {
            _townRoutes = townRoutes;
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
                _townRoutes.Update();
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
            var addRouteEvents = addItems.Select(itm => itm.DataModel).OfType<RouteEvent>().ToList();
            var curRouteEvents = Events.ToList();
            var addRouteEventsId = addRouteEvents.Select(stEv => stEv.Id).ToArray();
            var curRouteEventsId = curRouteEvents.Select(stEv => stEv.Id).ToArray();
            var nwRouteEventsId = addRouteEventsId.Except(curRouteEventsId).ToArray();
            var nwRouteEvents = addRouteEvents.Where(stEv => nwRouteEventsId.Contains(stEv.Id)).ToList();
            Events = curRouteEvents.Union(nwRouteEvents).ToList();
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
