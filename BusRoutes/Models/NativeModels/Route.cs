using BusRoutes.Models.NativeModels.Storages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.NativeModels
{
    public class Route
    {
        [Key]
        public long Id { get; set; }

        public int NumberOfRoute { get; set; }

        public Station BeginStation { get; set; }

        public Station EndStation { get; set; }

        public virtual List<Station> Stations { get; set; }

        public Route(long id, int numberOfRoute, Station beginStation, Station endStation, List<Station> stations = null)
        {
            Id = id;
            NumberOfRoute = numberOfRoute;
            BeginStation = beginStation;
            EndStation = endStation;

            Stations = new List<Station>();
            if (stations != null)
                Stations.AddRange(stations);    
        }

        Route()
        {
            Stations = new List<Station>();
        }

        public void Save(Route saveRoute)
        {
            NumberOfRoute = saveRoute.NumberOfRoute;
            BeginStation = saveRoute.BeginStation;
            EndStation = saveRoute.EndStation;
            Stations.Clear();
            Stations.AddRange(saveRoute.Stations);
        }

        public void Save()
        {
            BusRoutesStorageFactory.GetStorageFactory().GetStotage().Save(this);
        }

        public void Update()
        {
            BusRoutesStorageFactory.GetStorageFactory().GetStotage().Update(this);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Route rt = obj as Route;
            if (rt == null)
                return false;
            return Id == rt.Id;
        }
    }
}
