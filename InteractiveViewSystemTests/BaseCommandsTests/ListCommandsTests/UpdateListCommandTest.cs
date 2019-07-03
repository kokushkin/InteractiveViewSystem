using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System.Collections.Generic;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;

namespace InteractiveViewSystemTests.BaseCommandsTests.ListCommandsTests
{
    [TestClass]
    public class UpdateListCommandTest : BaseListCommandsTests
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Init();

            List<IItemModelAdapter<IEventModel>> newItems = new List<IItemModelAdapter<IEventModel>>();

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(980027, "Mole Hole", DateTime.Now, "Mole Hole station. 2 min.")));

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(180326, "Last station", DateTime.Now, "Last station. 3 min.")));

            model.AddItems(newItems);


            Assert.IsTrue(itemsVM.Count == 4);

            viewModel.UpdateListCommand.Execute(null);

            Assert.IsTrue(itemsVM.Count == 6);
        }
    }
}
