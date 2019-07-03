using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System.Collections.Generic;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System.Linq;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;

namespace InteractiveViewSystemTests.BaseCommandsTests.ListCommandsTests
{
    [TestClass]
    public class AddItemCommandTests :  BaseListCommandsTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == "Airport");

            viewModel.EditListCommand.Execute(null);

            viewModel.AddItemCommand.Execute(null);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == String.Empty);

            Assert.IsNotNull(itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == String.Empty));

            Assert.IsTrue(viewModel.CurrentVM.IsEditing);
        }
    }
}
