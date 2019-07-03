using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.Models.NativeModels.Storages
{
    public interface IBusRoutesStorage
    {
        void Save(Station saveStation);

        void Save(Route saveRoute);

        void Save(RoutesOfTown saveTown);

        void Update(Station updateStation);

        void Update(Route updateRoute);

        void Update(RoutesOfTown updateTown);

        RoutesOfTown LoadOneTown();
    }
}
