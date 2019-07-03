using DeliveryExample.Models.ProcessAndEvents;
using DeliveryExample.ProcessAndEventsCreaters;
using DeliveryExample.ServiceContracts;
using DeliveryExample.ViewModels;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
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

namespace DeliveryExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DeliveriesDistrubution DeliveriesDistributionVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DeliveriesDistributionVM = new DeliveriesDistrubution();

            this.DataContext = this;
        }
    }
}


