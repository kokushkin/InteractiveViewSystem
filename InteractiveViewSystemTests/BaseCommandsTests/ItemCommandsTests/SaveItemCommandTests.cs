using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;

namespace InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests
{
    [TestClass]
    public class SaveItemCommandTests : BaseItemCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            string changedDescription = "Ivanovo station. 10 min.";
            viewModel.DataViewModel.Description = changedDescription;

            viewModel.SaveCommand.Execute(null);

            Assert.IsFalse(viewModel.IsEditing);
            Assert.IsTrue(viewModel.IsSaved);

            Assert.IsTrue(model.DataModel.Description != firstDescription);
            Assert.IsTrue(model.DataModel.Description == changedDescription);
        }
    }
}
