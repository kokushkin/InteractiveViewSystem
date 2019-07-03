using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;

namespace InteractiveViewSystemTests.BaseCommandsTests.ItemCommandsTests
{
    [TestClass]
    public class UpdateItemCommandTest : BaseItemCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            string changedDescription = "Ivanovo station. 10 min.";

            model.DataModel.Description = changedDescription;

            viewModel.UpdateCommand.Execute(null);

            Assert.IsTrue(changedDescription == viewModel.DataViewModel.Description); 
        }
    }
}
