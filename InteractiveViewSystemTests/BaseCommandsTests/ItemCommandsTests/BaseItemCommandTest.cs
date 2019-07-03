using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;

namespace InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests
{

    public class BaseItemCommandTest
    {
        protected string firstDescription;

        protected IEventModel dataModel;

        protected ItemModelAdapterForPassive<IEventModel> model;

        protected IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModel;

        public void Init()
        {
            firstDescription = "Ivanovo station. 5 min.";

            dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            var viewModelCreator = new EventDataDetailViewModelCreator();
            var itemModelCreator = new EventModelAdapterCreator();

            viewModel = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);
        }
    }
}
