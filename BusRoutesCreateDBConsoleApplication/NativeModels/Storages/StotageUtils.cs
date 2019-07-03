using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.NativeModels.Storages
{
    public class StotageUtils
    {
        public static void GenerateTestDataAndSave()
        {
            List<Station> stationsRoute11 = new List<Station>();

            Route route11 = new Route(3452, 11, stationsRoute11.FirstOrDefault(), stationsRoute11.LastOrDefault(), stationsRoute11);

            var beginStation = new Station(235235, 1, "Ivanovo", GetTodayDateTime(9, 45), null, "Ivanovo station. 5 min.", route11);

            stationsRoute11.Add(beginStation);

            stationsRoute11.Add(new Station(945853, 2, "Airport", GetTodayDateTime(9, 50), null, "Airport station. 15 min.", route11));

            stationsRoute11.Add(new Station(124590, 3, "Lake", GetTodayDateTime(10, 10), null, "Lake station. 5 min. Temporarily closed.", route11));

            var endStation = new Station(744935, 4, "Central station.", GetTodayDateTime(10, 30), null, "Central station. 7 min.", route11);

            stationsRoute11.Add(endStation);

            route11.Stations = stationsRoute11;
            route11.BeginStation = beginStation;
            route11.EndStation = endStation;




            //List<Station> stationsRoute40 = new List<Station>();

            //stationsRoute40.Add(new Station(495637, 1, "Square", GetTodayDateTime(9, 35), null, "Square station. 7 min."));

            //stationsRoute40.Add(new Station(434588, 2, "BigShop", GetTodayDateTime(10, 50), null, "BigShop station. 5 min."));

            //stationsRoute40.Add(new Station(324589, 3, "Stadium", GetTodayDateTime(11, 10), null, "Stadium station. 5 min."));

            //stationsRoute40.Add(new Station(393428, 4, "River", GetTodayDateTime(12, 30), null, "River station. 11 min."));


            //Route route40 = new Route(9983, 40, stationsRoute40.FirstOrDefault(), stationsRoute40.LastOrDefault(), stationsRoute40);



            //List<Station> stationsRoute52 = new List<Station>();

            //stationsRoute52.Add(new Station(866442, 1, "Forest", GetTodayDateTime(11, 35), GetTodayDateTime(11, 38), "Forest station. 12 min."));

            //stationsRoute52.Add(new Station(124914, 2, "Farm", GetTodayDateTime(12, 38), GetTodayDateTime(12, 36), "Farm station. 4 min."));

            //stationsRoute52.Add(new Station(146593, 3, "Circus", GetTodayDateTime(16, 10), null, "Circus station. 7 min."));

            //stationsRoute52.Add(new Station(103801, 4, "Institute", GetTodayDateTime(18, 30), null, "Institute station. 10 min."));


            //Route route52 = new Route(8875, 52, stationsRoute52.FirstOrDefault(), stationsRoute52.LastOrDefault(), stationsRoute52);



            List<Route> routes = new List<Route>();
            routes.Add(route11);
            //routes.Add(route40);
            //routes.Add(route52);


            RoutesOfTown routesOfTown = new RoutesOfTown("Chester city routes", routes);
            routesOfTown.Id = 33234;

            using (BusRoutesContext context = new BusRoutesContext())
            {
                context.Towns.Add(routesOfTown);
                context.SaveChanges();
            }

        }

        public static DateTime GetTodayDateTime(int hour, int minute)
        {
            DateTime curDt = DateTime.Now;
            return new DateTime(curDt.Year, curDt.Month, curDt.Day, hour, minute, 0);
        }
    }
}
