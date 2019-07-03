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
    public class EditSaveListCommandTest : BaseListCommandsTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            viewModel.SelectItemCommand.Execute(airportVM);

            viewModel.EditListCommand.Execute(null);

            Assert.IsTrue(viewModel.IsEditing);
            Assert.IsFalse(viewModel.IsSaved);

            //новые станции

            viewModel.AddItemCommand.Execute(null);

            var current = viewModel.CurrentVM;

            current.DataViewModel.Id = 888372;
            current.DataViewModel.Name = "Big mall";
            current.DataViewModel.Description = "New station. Not opened yet.";

            current.Save();

            viewModel.AddItemCommand.Execute(null);

            current = viewModel.CurrentVM;

            current.DataViewModel.Id = 993726444;
            current.DataViewModel.Name = "Old town";
            current.DataViewModel.Description = "New station. Will opened after week";

            current.Save();

            //удаление станций

            var lakeStation = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Lake");

            viewModel.DeleteItemCommand.Execute(lakeStation);

            var ivanovoStation = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Ivanovo");

            viewModel.DeleteItemCommand.Execute(ivanovoStation);

            viewModel.SaveListCommand.Execute(null);

            var restStations = model.GetItems();

            Assert.IsFalse(viewModel.IsEditing);
            Assert.IsTrue(viewModel.IsSaved);

            Assert.IsTrue(restStations.Count() == 4);

            Assert.IsNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Lake"));
            Assert.IsNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Ivanovo"));

            Assert.IsNotNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Big mall"));
            Assert.IsNotNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Old town"));

        }
    }
}
