using BusRoutes.Models.NativeModels;
using BusRoutes.Models.NativeModels.Storages;
using BusRoutes.Models.ProcessAndEvents;
using BusRoutes.ProcessAndEventsCreaters;
using BusRoutes.ProcessAndEventsCreaters.SepareteCreators.RouteCreators;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusRoutes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IProcessViewModel RoutesOfTownProcessVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        static DateTime GetTodayDateTime(int hour, int minute)
        {
            DateTime curDt = DateTime.Now;
            return new DateTime(curDt.Year, curDt.Month, curDt.Day, hour, minute, 0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StotageUtils.GenerateTestDataAndSave();

            var oneTown = BusRoutesStorageFactory.GetStorageFactory().GetStotage().LoadOneTown();

            RoutesOfTownProcess routesOfTownProcessModel = new RoutesOfTownProcess(oneTown);

            ViewModelRouteEventCreator creator = new ViewModelRouteEventCreator();


            RoutesOfTownProcessVM = new ProcessViewModel(routesOfTownProcessModel, creator, new RouteEventModelAdapterCreator());

            this.DataContext = this;

        }

    }
}
