using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemTests.BaseCommandsTests.ListCommandsTests
{
    public class BaseListCommandsTests
    {
        protected IListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> viewModel;

        protected ObservableCollection<IItemViewModel<IEventModel, IEventViewModel>> itemsVM;

        protected IItemViewModel<IEventModel, IEventViewModel> airportVM;

        protected IListModel<IEventModel> model;

        protected void Init(bool letUpdateList = true)
        {
            model = new ListModel<IEventModel>();

            List<IItemModelAdapter<IEventModel>> items = new List<IItemModelAdapter<IEventModel>>();

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(235235, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 15 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(124590, "Lake", DateTime.Now, "Lake station. 5 min. Temporarily closed.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(744935, "Central station.", DateTime.Now, "Central station. 7 min.")));

            model.AddItems(items);

            var creator = new EventViewModelCreator();
            var eventModelCreator = new EventModelAdapterCreator();

            var vm = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(model, creator, eventModelCreator);
            vm.LetUpdate = letUpdateList;
            viewModel = vm;

            itemsVM = viewModel.ItemsVM;

            airportVM = itemsVM.FirstOrDefault(itmVM => itmVM.DataViewModel.Name == "Airport");

        }


    }
}
