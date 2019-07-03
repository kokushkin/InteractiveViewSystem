using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLog.Internal;

namespace BusRoutes.Models.NativeModels.Storages
{
    public class BusRoutesStorageFactory
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        const string STORAGE_CONFIG_KEY = "Storage";

        static BusRoutesStorageFactory factoryInstance;

        IBusRoutesStorage storage;

        public static BusRoutesStorageFactory GetStorageFactory()
        {
            if (factoryInstance == null)
                factoryInstance = new BusRoutesStorageFactory();
            return factoryInstance;
        }

        public IBusRoutesStorage GetStotage()
        {
            if(storage == null)
            {
                string storageClassName = System.Configuration.ConfigurationManager.AppSettings.Get(STORAGE_CONFIG_KEY);
                var storageType = Type.GetType(storageClassName);
                var storageConstructor = storageType.GetConstructor(Type.EmptyTypes);
                storage = (IBusRoutesStorage)storageConstructor.Invoke(new object[0]);
            }

            return storage;
        }

    }
}
