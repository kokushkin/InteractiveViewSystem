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
    public class SelectItemCommandTests : BaseListCommandsTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name);

            var lakeVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Lake");

            viewModel.SelectItemCommand.Execute(lakeVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == lakeVM.DataViewModel.Name);
        }
    }
}
