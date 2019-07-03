using BusRoutes.Models.NativeModels.Storages;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int? DeltaPassengers { get; set; }

        static Logger log = LogManager.GetCurrentClassLogger();

        public Station(long id, int number, string name, DateTime waitedArrival, DateTime? realArrival, string dopDescription)
        {
            Id = id;
            Number = number;
            Name = name;
            WaitedArrival = waitedArrival;
            RealArrival = realArrival;
            DopDescription = dopDescription;
        }

        public Station()
        {

        }

        public void Save(Station saveStation)
        {
            Number = saveStation.Number;
            Name = saveStation.Name;
            WaitedArrival = saveStation.WaitedArrival;
            RealArrival = saveStation.RealArrival;
            DopDescription = saveStation.DopDescription;
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
            Station st = obj as Station;
            if (st == null)
                return false;
            return Id == st.Id;
        }
    }
}
