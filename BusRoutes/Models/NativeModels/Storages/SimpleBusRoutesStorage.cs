using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusRoutes.Models.NativeModels.Storages
{
    public class SimpleBusRoutesStorage : IBusRoutesStorage
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        public void Save(Station saveStation)
        {
            try
            {
                using (BusRoutesContext context = new BusRoutesContext())
                {
                    if (saveStation.Id == 0)
                        context.Stations.Add(saveStation);
                    else
                        context.Entry(saveStation).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Save(Route saveRoute)
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                if (saveRoute.Id == 0)
                {
                    context.Routes.Add(saveRoute);
                }
                else
                {
                    //load route with stations
                    var baseRoute = context.Routes.Include(rt => rt.Stations)
                        .SingleOrDefault(rt => rt.Id == saveRoute.Id);

                    var idsBaseStationNotIntoBaseRoute = saveRoute.Stations.Except(baseRoute.Stations)
                        .Where(st => st.Id != 0).Select(st => st.Id).ToList();

                    var baseSavedStationNotIntoRoute = context.Stations.Where(st => idsBaseStationNotIntoBaseRoute.Contains(st.Id)).ToList();

                    //attaching stations saved in database into route 
                    foreach (var baseStation in baseSavedStationNotIntoRoute)
                    {
                        baseRoute.Stations.Add(baseStation);
                    }

                    //deleting old stations
                    //can erase new records from other users!!!!!
                    foreach (var station in baseRoute.Stations.Except(saveRoute.Stations).ToList())
                    {
                        baseRoute.Stations.Remove(station);
                    }

                }
                context.SaveChanges();
            }
        }

        public void Save(RoutesOfTown saveTown)
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                if (saveTown.Id == 0)
                {
                    context.Towns.Add(saveTown);
                }
                else
                {
                    //load town with routes
                    var baseTown = context.Towns.Include(tn => tn.Routes)
                        .SingleOrDefault(tn => tn.Id == saveTown.Id);

                    var idsBaseRoutesNotIntoBaseTown = saveTown.Routes.Except(baseTown.Routes)
                        .Where(rt => rt.Id != 0).Select(rt => rt.Id).ToList();

                    var baseSavedRoutesNotIntoTown = context.Routes
                        .Where(rt => idsBaseRoutesNotIntoBaseTown.Contains(rt.Id)).ToList();

                    //attaching routes saved in database into town 
                    foreach (var baseRoute in baseSavedRoutesNotIntoTown)
                    {
                        baseTown.Routes.Add(baseRoute);
                    }

                    //deleting old routes
                    //can erase new records from other users!!!!!
                    foreach (var route in baseTown.Routes.Except(saveTown.Routes).ToList())
                    {
                        baseTown.Routes.Remove(route);
                    }
                }

                context.SaveChanges();
            }
        }

        public void Update(Station updateStation)
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                var stationFromBase = context.Stations
                    .FirstOrDefault(st => st.Id == updateStation.Id);
                updateStation.Save(stationFromBase);
            }
        }

        public void Update(Route updateRoute)
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                var stationFromBase = context.Routes
                    .Include(rt => rt.Stations)
                    .FirstOrDefault(rt => rt.Id == updateRoute.Id);
                updateRoute.Save(stationFromBase);
            }
        }

        public void Update(RoutesOfTown updateTown)
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                var townFromBase = context.Towns
                    .Include(tn => tn.Routes.Select(rt => rt.Stations))
                    .FirstOrDefault(tn => tn.Id == updateTown.Id);
                updateTown.Save(townFromBase);
            }
        }

        public RoutesOfTown LoadOneTown()
        {
            using (BusRoutesContext context = new BusRoutesContext())
            {
                var town = context.Towns
                    .Include(tn => tn.Routes.Select(rt => rt.Stations))
                    .FirstOrDefault();
                return town;
            }
        }

    }
}
