using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.BaseCreators;
using InteractiveViewSystem.GeneralizedModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;

namespace InteractiveViewSystemTests.BaseViewModelsTests
{
    [TestClass]
    public class DetailItemViewModelTests : BaseViewModelTest
    {
        //IModelsAndViewModelsCreator<IEventModel, IEventViewModel, IDetailEventViewModel> creator;

        //public DetailItemViewModelTests()
        //{
        //    creator = new EventModelAndViewModelEventCreator();
        //}
        
        [TestMethod]
        public void OnUpdateTest()
        {
            Init();

            string changedDescription = "Ivanovo station. 10 min.";

            dataModel.Description = changedDescription;

            model.Update();

            Assert.IsTrue(changedDescription == viewModel.DataViewModel.Description);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Init();

            string changedDescription = "Ivanovo station. 10 min.";

            dataModel.Description = changedDescription;

            viewModel.Update();

            Assert.IsTrue(changedDescription == viewModel.DataViewModel.Description);
        }

        [TestMethod]
        public void EditSaveTest()
        {
            Init();

            viewModel.Edit();

            Assert.IsTrue(viewModel.IsEditing);
            Assert.IsFalse(viewModel.IsSaved);

            string changedDescription = "Ivanovo station. 10 min.";
            viewModel.DataViewModel.Description = changedDescription;

            Assert.IsTrue(model.DataModel.Description == firstDescription);
            Assert.IsTrue(model.DataModel.Description != changedDescription);

            viewModel.Save();

            Assert.IsFalse(viewModel.IsEditing);
            Assert.IsTrue(viewModel.IsSaved);

            Assert.IsTrue(model.DataModel.Description != firstDescription);
            Assert.IsTrue(model.DataModel.Description == changedDescription);
        }

        [TestMethod]
        public void CanGetUpdateAfterEditOnce()
        {
            firstDescription = "Ivanovo station. 5 min.";

            dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            var viewModelCreator = new EventDataDetailViewModelCreator();
            var itemModelCreator = new EventModelAdapterCreator();

            dataViewModel = new DetailEventViewModel(dataModel);

            IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModelLeft
    = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);

            IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModelRight
    = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);


            viewModelRight.Edit();
            viewModelRight.Save();

            string secondDescription = "Ivanovo station. 10 min.";

            viewModelLeft.Edit();
            viewModelLeft.DataViewModel.Description = secondDescription;
            viewModelLeft.Save();

            Assert.IsTrue(viewModelRight.DataViewModel.Description == secondDescription);
        }
    }
}
