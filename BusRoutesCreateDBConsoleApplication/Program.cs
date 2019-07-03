using BusRoutes.Models.NativeModels.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutesCreateDBConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            StotageUtils.GenerateTestDataAndSave();
        }
    }
}
