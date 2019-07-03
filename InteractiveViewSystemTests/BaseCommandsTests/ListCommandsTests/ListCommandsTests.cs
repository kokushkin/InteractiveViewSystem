using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;
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
    public class ListCommandsTests : BaseListCommandsTests
    {
        [TestMethod]
        public void ChangeCommandsTest()
        {
            Init(false);

            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsFalse(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsFalse(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsFalse(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());



            List<IItemModelAdapter<IEventModel>> newItems = new List<IItemModelAdapter<IEventModel>>();

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(980027, "Mole Hole", DateTime.Now, "Mole Hole station. 2 min.")));

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(180326, "Last station", DateTime.Now, "Last station. 3 min.")));

            model.AddItems(newItems);



            viewModel.UpdateListCommand.Execute(null);

            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsFalse(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsFalse(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsFalse(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());

            var airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");

            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsFalse(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsFalse(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsFalse(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());

            viewModel.EditListCommand.Execute(null);

            Assert.IsFalse(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsFalse(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());


            viewModel.AddItemCommand.Execute(null);

            viewModel.CurrentVM.DataViewModel.Id = 5374623654;
            viewModel.CurrentVM.DataViewModel.Name = "XX century";
            viewModel.CurrentVM.DataViewModel.Description = "station was built in XX century.";

            viewModel.CurrentVM.SaveCommand.Execute(null);

            Assert.IsFalse(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsFalse(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());

            airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");

            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsFalse(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsFalse(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());

            viewModel.DeleteItemCommand.Execute(airportVM);

            Assert.IsFalse(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsFalse(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());

            viewModel.SaveListCommand.Execute(null);

            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.UpdateListCommand.CanExecute(null) == viewModel.CanUpdateList());

            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.EditListCommand.CanExecute(null) == viewModel.CanEditList());

            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SelectItemCommand.CanExecute(null) == viewModel.CanSelectItem());

            Assert.IsFalse(viewModel.AddItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.AddItemCommand.CanExecute(null) == viewModel.CanAddItem());

            Assert.IsFalse(viewModel.DeleteItemCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteItemCommand.CanExecute(null) == viewModel.CanDeleteItem());

            Assert.IsFalse(viewModel.SaveListCommand.CanExecute(null));
            Assert.IsTrue(viewModel.SaveListCommand.CanExecute(null) == viewModel.CanSaveList());



        }

        [TestMethod]
        public void CanExecuteChangedTest()
        {
            Init();

            bool CanExecuteUpdateListWasSant = false;
            bool CanExecuteSelectItemWasSant = false;
            bool CanExecuteEditListWasSant = false;
            bool CanExecuteAddItemWasSant = false;
            bool CanExecuteDeleteItemWasSant = false;
            bool CanExecuteSaveListWasSant = false;

            viewModel.UpdateListCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteUpdateListWasSant = true;
            };

            viewModel.SelectItemCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteSelectItemWasSant = true;
            };

            viewModel.EditListCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteEditListWasSant = true;
            };

            viewModel.AddItemCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteAddItemWasSant = true;
            };

            viewModel.DeleteItemCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteDeleteItemWasSant = true;
            };

            viewModel.SaveListCommand.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                CanExecuteSaveListWasSant = true;
            };


            viewModel.UpdateListCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;


            var airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");
            viewModel.SelectItemCommand.Execute(airportVM);

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;


            viewModel.EditListCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;


            viewModel.AddItemCommand.Execute(null);

            viewModel.CurrentVM.DataViewModel.Id = 5374623654;
            viewModel.CurrentVM.DataViewModel.Name = "XX century";
            viewModel.CurrentVM.DataViewModel.Description = "station was built in XX century.";

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;


            airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");
            viewModel.DeleteItemCommand.Execute(airportVM);

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;


            viewModel.SaveListCommand.Execute(null);

            Assert.IsTrue(CanExecuteUpdateListWasSant);
            Assert.IsTrue(CanExecuteSelectItemWasSant);
            Assert.IsTrue(CanExecuteEditListWasSant);
            Assert.IsTrue(CanExecuteAddItemWasSant);
            Assert.IsTrue(CanExecuteDeleteItemWasSant);
            Assert.IsTrue(CanExecuteSaveListWasSant);

            CanExecuteUpdateListWasSant = false;
            CanExecuteSelectItemWasSant = false;
            CanExecuteEditListWasSant = false;
            CanExecuteAddItemWasSant = false;
            CanExecuteDeleteItemWasSant = false;
            CanExecuteSaveListWasSant = false;

        }

        [TestMethod]
        public void ProcessCanNotBeUpdatedWhileItEdit()
        {
            IListModel<IEventModel> model = new ListModel<IEventModel>();

            List<IItemModelAdapter<IEventModel>> items = new List<IItemModelAdapter<IEventModel>>();

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(235235, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 15 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(124590, "Lake", DateTime.Now, "Lake station. 5 min. Temporarily closed.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(744935, "Central station.", DateTime.Now, "Central station. 7 min.")));

            model.AddItems(items);

            var creator = new EventViewModelCreator();
            var eventModelCreator = new EventModelAdapterCreator();

            var vmFirst = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(model, creator, eventModelCreator);
            vmFirst.LetUpdate = false;
            IListViewModel <IEventModel, IEventViewModel, IDetailEventViewModel> viewModelFirst = vmFirst;

            var itemsVMFirst = viewModelFirst.ItemsVM;

            var vmSecond = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(model, creator, eventModelCreator);
            vmSecond.LetUpdate = false;
            IListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> viewModelSecond = vmSecond;

            var itemsVMSecond = viewModelSecond.ItemsVM;


            viewModelFirst.EditListCommand.Execute(null);

            viewModelSecond.EditListCommand.Execute(null);

            viewModelSecond.AddItemCommand.Execute(null);

            viewModelSecond.CurrentVM.DataViewModel.Id = 5374623654;
            viewModelSecond.CurrentVM.DataViewModel.Name = "XX century";
            viewModelSecond.CurrentVM.DataViewModel.Description = "station was built in XX century.";

            viewModelSecond.CurrentVM.SaveCommand.Execute(null);

            viewModelSecond.SaveListCommand.Execute(null);

            Assert.IsNull(itemsVMFirst.FirstOrDefault(ev => ev.DataViewModel.Name == "XX century"));

            Assert.IsTrue(itemsVMFirst.Count == 4);
        }
    }
}
