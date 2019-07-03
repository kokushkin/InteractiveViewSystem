using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;

namespace InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests
{
    [TestClass]
    public class EditItemCommandTests : BaseItemCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            viewModel.EditCommand.Execute(null);

            Assert.IsTrue(viewModel.IsEditing);
            Assert.IsFalse(viewModel.IsSaved);

            string changedDescription = "Ivanovo station. 10 min.";
            viewModel.DataViewModel.Description = changedDescription;

            Assert.IsTrue(model.DataModel.Description == firstDescription);
            Assert.IsTrue(model.DataModel.Description != changedDescription);
        }
    }
}
