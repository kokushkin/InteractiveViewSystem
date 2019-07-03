using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System.Collections.Generic;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System.Linq;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;

namespace InteractiveViewSystemTests.BaseCommandsTests.ListCommandsTests
{
    [TestClass]
    public class DeleteItemCommandTests : BaseListCommandsTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name);

            viewModel.EditListCommand.Execute(null);

            viewModel.DeleteItemCommand.Execute(airportVM);

            airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");

            Assert.IsNull(airportVM);

            if (viewModel.CurrentVM != null)
            {
                Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name != "Airport");
            }
        }
    }
}
