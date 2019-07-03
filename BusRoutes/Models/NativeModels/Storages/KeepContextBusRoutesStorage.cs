using NLog;
using System;
using System.Linq;
using System.Data.Entity;

namespace BusRoutes.Models.NativeModels.Storages
{
    public class KeepContextBusRoutesStorage : IBusRoutesStorage, IDisposable
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        BusRoutesContext context;

        public KeepContextBusRoutesStorage()
        {
            context = new BusRoutesContext();
        }

        public void Save(Station saveStation)
        {
            try
            {
                if (saveStation.Id == 0)
                    context.Stations.Add(saveStation);
                string logStr = string.Empty;
                context.Database.Log += str => logStr += str + Environment.NewLine;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Save(Route saveRoute)
        {
            try
            {
                if (saveRoute.Id == 0)
                    context.Routes.Add(saveRoute);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Save(RoutesOfTown saveTown)
        {
            try
            {
                if (saveTown.Id == 0)
                    context.Towns.Add(saveTown);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Update(Station updateStation)
        {
            try
            {
                context.Entry(updateStation).Reload();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Update(Route updateRoute)
        {
            try
            {
                context.Entry(updateRoute).Reload();
                context.Entry(updateRoute)
                    .Collection(rt => rt.Stations)
                    .Load();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Update(RoutesOfTown updateTown)
        {
            try
            {
                context.Entry(updateTown).Reload();
                context.Entry(updateTown)
                    .Collection(rt => rt.Routes)
                    .Load();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }    
        }

        public RoutesOfTown LoadOneTown()
        {
            try
            {
                var town = context.Towns
            .Include(tn => tn.Routes.Select(rt => rt.Stations))
            .FirstOrDefault();
                return town;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }         
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
