using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseViewModels
{
    public class DetailItemViewModelTimer<DataModelType, DataDetailViewModelType> : 
        DetailItemViewModel<DataModelType, DataDetailViewModelType>
        where DataDetailViewModelType : IItemDataViewModel
    {
        System.Windows.Threading.DispatcherTimer timer;

        public DetailItemViewModelTimer(IItemModelAdapter<DataModelType> model,
            IDataDetailViewModelCreator<DataModelType, DataDetailViewModelType> viewModelCreator,
            IItemModelAdapterCreator<DataModelType> itemModelCreator, int updateInterval = 5) :
            base(model, viewModelCreator, itemModelCreator)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, updateInterval);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Update();
        }
    }
}
