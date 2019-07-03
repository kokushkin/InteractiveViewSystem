using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusRoutes.Models.NativeModels.Storages;

namespace BusRoutes.Models.NativeModels
{
    public class RoutesOfTown
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Route> Routes { get; set; }

        public int NumberOfRoutes
        {
            get
            {
                return Routes.Count;
            }
        }

        public RoutesOfTown(string name, List<Route> routes = null)
        {
            Name = name;
            if (routes == null)
                Routes = new List<Route>();
            else
                Routes = routes;
        }

        RoutesOfTown()
        {
            Routes = new List<Route>();
        }

        public void Save(RoutesOfTown saveTown)
        {
            Name = saveTown.Name;
            Routes.Clear();
            Routes.AddRange(saveTown.Routes);
        }

        public void Save()
        {
            BusRoutesStorageFactory.GetStorageFactory().GetStotage().Save(this);
        }

        public void Update()
        {
            BusRoutesStorageFactory.GetStorageFactory().GetStotage().Update(this);
        }
    }
}
