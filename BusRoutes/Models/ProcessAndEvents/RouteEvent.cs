using BusRoutes.Models.NativeModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusRoutes.Models.ProcessAndEvents
{
    public class RouteEvent : IEventModel
    {
        Route _route;

        public long Id
        {
            get
            {
                return _route.Id;
            }
            set
            {
                _route.Id = value;
            }
        }

        public string Name
        {
            get
            {
                if (_route.BeginStation != null && _route.EndStation != null)
                    return string.Format("{0} - {1}", _route.BeginStation.Name, _route.EndStation.Name);
                else
                    return "Unknown";
            }
            set
            {
                Regex rgx = new Regex(@"^(?<from>.+?)\s*\-\s*(?<to>.+)$");
                Match mch = null;
                if((mch = rgx.Match(value)).Success)
                {
                    if(_route.BeginStation != null && _route.EndStation != null)
                    {
                        _route.BeginStation.Name = mch.Groups["from"].Value;
                        _route.EndStation.Name = mch.Groups["to"].Value;
                    }
                    else
                    {
                        Station fromStation = new Station(0, 0, mch.Groups["from"].Value, DateTime.Now, null, "FirstStation");
                        Station endStation = new Station(0, 1, mch.Groups["to"].Value, DateTime.Now.AddDays(1), null, "LastStation");
                        _route.Stations.Add(fromStation);
                        _route.Stations.Add(endStation);
                        _route.BeginStation = fromStation;
                        _route.EndStation = endStation;
                    }
                }
            }
        }

        public DateTime Time
        {
            get
            {
                if (_route.BeginStation != null)
                    return _route.BeginStation.WaitedArrival;
                else
                    return DateTime.Now;
            }
            set
            {
                _route.BeginStation.WaitedArrival = value;
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
                Regex rgx = new Regex(@"(?<routNumber>\d+)");
                Match mch = null;
                if ((mch = rgx.Match(value)).Success)
                {
                    _route.NumberOfRoute = int.Parse(mch.Groups["routNumber"].Value);
                }
            }
        }

        IProcessModel routeProcess;
        public IProcessModel SubProcess
        {
            get
            {
                return routeProcess;
            }
            set
            {
                routeProcess = value;
            }
        }

        public RouteEvent(Route route)
        {
            _route = route;
            routeProcess = new RouteProcess(_route);
        }

        public void Save(IEventModel saveDataModel)
        {
            Id = saveDataModel.Id;
            Name = saveDataModel.Name;
            Time = saveDataModel.Time;
            Description = saveDataModel.Description;
            SubProcess = saveDataModel.SubProcess;

            _route.Save();
        }

        public void Update()
        {
            _route.Update();
        }

        public void AddToRoute(RoutesOfTown routesOfTown)
        {
            routesOfTown.Routes.Add(_route);
        }

        public RouteEvent Copy()
        {
            Route nwRoute = new Route(_route.Id, _route.NumberOfRoute, _route.BeginStation, _route.EndStation, _route.Stations);
            return new RouteEvent(nwRoute);
        }
    }
}
