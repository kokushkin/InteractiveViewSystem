using BusRoutes.Models.NativeModels.Storages;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.NativeModels
{
    public class Station
    {
        [Key]
        public long Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public DateTime WaitedArrival { get; set; }

        public DateTime? RealArrival { get; set; }

        public string DopDescription { get; set; }

        //[ForeignKey("Route")]
        //public virtual long RouteId { get; set; }

        //public virtual Route Route {get; set;}

        static Logger log = LogManager.GetCurrentClassLogger();

        public Station(long id, int number, string name, DateTime waitedArrival, DateTime? realArrival, string dopDescription, Route route)
        {
            Id = id;
            Number = number;
            Name = name;
            WaitedArrival = waitedArrival;
            RealArrival = realArrival;
            DopDescription = dopDescription;
            //Route = route;
            //RouteId = route.Id;
        }

        public Station()
        {

        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Station st = obj as Station;
            if (st == null)
                return false;
            return Id == st.Id;
        }
    }
}
