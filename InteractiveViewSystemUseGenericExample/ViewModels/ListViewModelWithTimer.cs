using System;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;

namespace InteractiveViewSystemUseGenericExample.ViewModels
{
    public class ListViewModelWithTimer<DataModelType, DataViewModelType, DataDetailViewModelType> :
        ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        System.Windows.Threading.DispatcherTimer timer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="creator"></param>
        /// <param name="itemModelCreator"></param>
        /// <param name="updateInterval">интервал обновления в секундах</param>
        public ListViewModelWithTimer(IListModel<DataModelType> model,
        IViewModelCreator<DataModelType, DataViewModelType, DataDetailViewModelType> creator,
        IItemModelAdapterCreator<DataModelType> itemModelCreator, int updateInterval = 5) :
            base(model, creator, itemModelCreator)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, updateInterval);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //UpdateList();
            if (UpdateListCommand.CanExecute(null))
                UpdateListCommand.Execute(null);
        }
    }
}
