using System;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;

namespace InteractiveViewSystemUseGenericExample.ViewModels
{
    public class DetailItemViewModelTimer<DataModelType, DataDetailViewModelType> : 
        DetailItemViewModel<DataModelType, DataDetailViewModelType>, IDisposable
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

        public void Dispose()
        {
            timer.Tick -= Timer_Tick;
        }
    }
}
