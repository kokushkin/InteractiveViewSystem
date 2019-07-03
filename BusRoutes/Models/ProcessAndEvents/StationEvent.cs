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
    public class StationEvent : IEventModel
    {
        Station _station;

        public long Id
        {
            get
            {
                return _station.Id;
            }
            set
            {
                _station.Id = value;
            }
        }

        public string Name
        {
            get
            {
                return _station.Name;
            }
            set
            {
                _station.Name = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return _station.RealArrival ?? _station.WaitedArrival;
            }
            set
            {
                if(_station.Id == 0)
                {
                    _station.WaitedArrival = value;
                }
                else
                {
                    _station.RealArrival = value;
                }
                
            }
        }

        public string Description
        {
            get
            {
                return string.Format("Number station is {0}. {1}", _station.Number, _station.DopDescription);
            }
            set
            {
                Match mch = null;
                if ((mch = Regex.Match(value, @"^Number station is (?<number>\d+)\. (?<Description>.+)$")).Success)
                {
                    _station.Number = int.Parse(mch.Groups["number"].Value);
                    _station.DopDescription = mch.Groups["Description"].Value;
                }
            }
        }

        public IProcessModel SubProcess
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public StationEvent(Station station)
        {
            _station = station;
        }

        public void Save(IEventModel saveDataModel)
        {
            Id = saveDataModel.Id;
            Name = saveDataModel.Name;
            Time = saveDataModel.Time;
            Description = saveDataModel.Description;
            SubProcess = saveDataModel.SubProcess;

            _station.Save();
        }

        public void Update()
        {
            _station.Update();
        }

        public void AddToRoute(Route route)
        {
            route.Stations.Add(_station);
        }

        public StationEvent Copy()
        {
            Station nwStation = new Station(_station.Id, _station.Number, _station.Name, _station.WaitedArrival, _station.RealArrival, _station.DopDescription);
            return new StationEvent(nwStation);
        }
    }
}
