using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemTests.BaseViewModelsTests
{
    public class BaseViewModelTest
    {
        protected string firstDescription;

        protected IEventModel dataModel;

        protected ItemModelAdapterForPassive<IEventModel> model;

        protected IDetailEventViewModel dataViewModel;

        protected IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModel;

        public void Init()
        {
            firstDescription = "Ivanovo station. 5 min.";

            dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            var viewModelCreator = new EventDataDetailViewModelCreator();
            var itemModelCreator = new EventModelAdapterCreator();

            dataViewModel = new DetailEventViewModel(dataModel);

            viewModel = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);
        }
    }
}
