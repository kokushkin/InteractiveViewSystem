using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseCreators;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;

namespace InteractiveViewSystemTests.BaseViewModelsTests
{
    [TestClass]
    public class ItemViewModelTests
    {

        IDataViewModelCreator<IEventModel, IEventViewModel> creator;

        public ItemViewModelTests()
        {
            creator = new EventDataViewModelCreator();;
        }

        [TestMethod]
        public void GetItemModelTest()
        {
            IEventModel dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min.");

            IItemModelAdapter<IEventModel> model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            IEventViewModel eventViewModel = new EventViewModel(dataModel);

            IItemViewModel<IEventModel, IEventViewModel> viewModel
                = new ItemViewModel<IEventModel, IEventViewModel>(model, creator);
            
            var modelFromViewModel = viewModel.GetItemModel();

            Assert.AreEqual(model, modelFromViewModel);
        }

        [TestMethod]
        public void OnUpdateTest()
        {
            string firstDescription = "Ivanovo station. 5 min.";

            IEventModel dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            IItemModelAdapter<IEventModel> model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            IEventViewModel eventViewModel = new EventViewModel(dataModel);

            EventDataViewModelCreator eventVMCreator = new EventDataViewModelCreator();

            IItemViewModel<IEventModel, IEventViewModel> viewModel
                = new ItemViewModel<IEventModel, IEventViewModel>(model, creator);

            string changedDescription = "Ivanovo station. 10 min.";

            model.DataModel.Description = changedDescription;

            model.Update();

            Assert.IsTrue(changedDescription == viewModel.DataViewModel.Description);
        }
    }
}
