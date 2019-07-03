using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;

namespace InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests
{
    [TestClass]
    public class ItemCommandTests : BaseItemCommandTest
    {
        [TestMethod]
        public void СhangeСommandsTest()
        {
            Init();

            Assert.IsFalse(viewModel.SaveCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanSave() == viewModel.SaveCommand.CanExecute(null));

            Assert.IsTrue(viewModel.EditCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanEdit() == viewModel.EditCommand.CanExecute(null));

            Assert.IsTrue(viewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanUpdate() == viewModel.UpdateCommand.CanExecute(null));

            string changedDescription = "Ivanovo station. 10 min.";

            model.DataModel.Description = changedDescription;

            //все нормально
            //Assert.IsFalse(viewModel.Description == changedDescription);

            viewModel.UpdateCommand.Execute(null);

            Assert.IsFalse(viewModel.SaveCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanSave() == viewModel.SaveCommand.CanExecute(null));

            Assert.IsTrue(viewModel.EditCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanEdit() == viewModel.EditCommand.CanExecute(null));

            Assert.IsTrue(viewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanUpdate() == viewModel.UpdateCommand.CanExecute(null));

            Assert.IsTrue(viewModel.DataViewModel.Description == changedDescription);

            viewModel.EditCommand.Execute(null);

            changedDescription = "Ivanovo station. Temporarily closed.";

            viewModel.DataViewModel.Description = changedDescription;

            Assert.IsFalse(viewModel.DataViewModel.Description == model.DataModel.Description);

            Assert.IsTrue(viewModel.SaveCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanSave() == viewModel.SaveCommand.CanExecute(null));

            Assert.IsFalse(viewModel.EditCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanEdit() == viewModel.EditCommand.CanExecute(null));

            Assert.IsFalse(viewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanUpdate() == viewModel.UpdateCommand.CanExecute(null));

            viewModel.SaveCommand.Execute(null);

            Assert.IsTrue(viewModel.DataViewModel.Description == model.DataModel.Description);

            Assert.IsFalse(viewModel.SaveCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanSave() == viewModel.SaveCommand.CanExecute(null));

            Assert.IsTrue(viewModel.EditCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanEdit() == viewModel.EditCommand.CanExecute(null));

            Assert.IsTrue(viewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CanUpdate() == viewModel.UpdateCommand.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteChangedTest()
        {
            Init();

            bool CanExecuteUpdateChangedWasSant = false;
            bool CanExecuteEditChangedWasSant = false;
            bool CanExecuteSaveChangedWasSant = false;

            viewModel.UpdateCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteUpdateChangedWasSant = true;
            };

            viewModel.EditCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteEditChangedWasSant = true;
            };

            viewModel.SaveCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteSaveChangedWasSant = true;
            };

            viewModel.UpdateCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateChangedWasSant);
            Assert.IsTrue(CanExecuteEditChangedWasSant);
            Assert.IsTrue(CanExecuteSaveChangedWasSant);

            CanExecuteUpdateChangedWasSant = false;
            CanExecuteEditChangedWasSant = false;
            CanExecuteSaveChangedWasSant = false;

            viewModel.EditCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateChangedWasSant);
            Assert.IsTrue(CanExecuteEditChangedWasSant);
            Assert.IsTrue(CanExecuteSaveChangedWasSant);

            CanExecuteUpdateChangedWasSant = false;
            CanExecuteEditChangedWasSant = false;
            CanExecuteSaveChangedWasSant = false;

            viewModel.SaveCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateChangedWasSant);
            Assert.IsTrue(CanExecuteEditChangedWasSant);
            Assert.IsTrue(CanExecuteSaveChangedWasSant);
        }

        [TestMethod]
        public void EventCanNotBeUpdatedWhileItEdit()
        {

            firstDescription = "Ivanovo station. 5 min.";

            dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            model = new ItemModelAdapterForPassive<IEventModel>(dataModel);

            var viewModelCreator = new EventDataDetailViewModelCreator();
            var itemModelCreator = new EventModelAdapterCreator();

            IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModelFirst
                = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);

            IDetailItemViewModel<IEventModel, IDetailEventViewModel> viewModelSecond
    = new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model, viewModelCreator, itemModelCreator);


            viewModelFirst.EditCommand.Execute(null);


            viewModelSecond.EditCommand.Execute(null);

            var changedDescription = "Ivanovo station. Temporarily closed.";

            viewModelSecond.DataViewModel.Description = changedDescription;

            viewModelSecond.SaveCommand.Execute(null);

            Assert.IsTrue(viewModelFirst.DataViewModel.Description == firstDescription);
        }
    }
}
