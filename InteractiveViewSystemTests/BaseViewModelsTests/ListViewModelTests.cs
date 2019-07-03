using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.BaseModels;
using System.Collections.Generic;
using System.Linq;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystemTests.BaseCommandsTests.ListCommandsTests;

namespace InteractiveViewSystemTests.BaseViewModelsTests
{
    [TestClass]
    public class ListViewModelTests : BaseListCommandsTests
    {
        [TestMethod]
        public void SelectTest()
        {
            Init();

            viewModel.SelectItem(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name);

            var lakeVM = itemsVM.FirstOrDefault(itmVM => itmVM.DataViewModel.Name == "Lake");

            viewModel.SelectItem(lakeVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == lakeVM.DataViewModel.Name);

        }


        [TestMethod]
        public void UpdateListTest()
        {
            Init();

            List<IItemModelAdapter<IEventModel>> newItems = new List<IItemModelAdapter<IEventModel>>();

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(980027, "Mole Hole", DateTime.Now, "Mole Hole station. 2 min.")));

            newItems.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(180326, "Last station", DateTime.Now, "Last station. 3 min.")));

            model.AddItems(newItems);

            Assert.IsTrue(itemsVM.Count == 4);

            viewModel.UpdateList();

            Assert.IsTrue(itemsVM.Count == 6);
        }

        [TestMethod]
        public void AddItemTest()
        {
            Init();

            viewModel.SelectItem(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == "Airport");

            viewModel.EditList();

            viewModel.AddItem();

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == String.Empty);

            Assert.IsNotNull(itemsVM.FirstOrDefault(itemVM => itemVM.DataViewModel.Name == String.Empty));
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            Init();

            //устанавливаем текущим "аэропорт", и он должен быть удален как текущий, когда он удаляется 

            viewModel.SelectItem(airportVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name);

            viewModel.EditList();

            viewModel.DeleteItem(airportVM);

            airportVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Airport");

            Assert.IsNull(airportVM);

            if (viewModel.CurrentVM != null)
            {
                Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name != "Airport");
            }

            //устанавливаем текущим "Ivanovo" и он должен остаться текущим когда удаляем "Lake"

            var ivanovoVM = itemsVM.FirstOrDefault(itemVM => itemVM.DataViewModel.Name == "Ivanovo");
            var lakeVM = itemsVM.FirstOrDefault(itemVM => itemVM.DataViewModel.Name == "Lake");

            viewModel.SelectItem(ivanovoVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == ivanovoVM.DataViewModel.Name);

            viewModel.EditList();

            viewModel.DeleteItem(lakeVM);

            lakeVM = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Lake");

            Assert.IsNull(lakeVM);

            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == "Ivanovo");
        }

        [TestMethod]
        public void EditSaveTest()
        {
            Init();

            viewModel.SelectItem(airportVM);

            viewModel.EditList();

            Assert.IsTrue(viewModel.IsEditing);
            Assert.IsFalse(viewModel.IsSaved);

            //новые станции

            viewModel.AddItem();

            var current = viewModel.CurrentVM;

            current.DataViewModel.Id = 888372;
            current.DataViewModel.Name = "Big mall";
            current.DataViewModel.Description = "New station. Not opened yet.";

            current.Save();

            viewModel.AddItem();

            current = viewModel.CurrentVM;

            current.DataViewModel.Id = 993726444;
            current.DataViewModel.Name = "Old town";
            current.DataViewModel.Description = "New station. Will opened after week";

            current.Save();

            //удаление станций

            var lakeStation = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Lake");

            viewModel.DeleteItem(lakeStation);

            var ivanovoStation = itemsVM.FirstOrDefault(evVM => evVM.DataViewModel.Name == "Ivanovo");

            viewModel.DeleteItem(ivanovoStation);

            viewModel.SaveList();

            var restStations = model.GetItems();

            Assert.IsFalse(viewModel.IsEditing);
            Assert.IsTrue(viewModel.IsSaved);

            Assert.IsTrue(restStations.Count() == 4);

            Assert.IsNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Lake"));
            Assert.IsNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Ivanovo"));

            Assert.IsNotNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Big mall"));
            Assert.IsNotNull(restStations.FirstOrDefault(st => st.DataModel.Name == "Old town"));
        }

        //при удалении всех элементов списка, в текущей реализации, устанавливается SelectedItem = null
        //при этом не должно быть проблем
        [TestMethod]
        public void ClearAllElements()
        {
            Init();

            itemsVM.Clear();

            viewModel.SelectedItem = null;
        }

        //тест о том, что если элемент выделен и он есть в обновлении,
        //то он остается выделенным,
        //в противном случае, он исчезает
        [TestMethod]
        public void UpdateWhenElementSelected()
        {
            Init();

            //выбираем этот элемент
            //viewModel.SelectItem(airportVM);
            viewModel.SelectedItem = airportVM;

            //делаем обновление и при этом приходят элементы, в которых есть текущий
            viewModel.UpdateList();

            //элемент находится выбранным как в подробном обзоре так и в списке
            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name);
            Assert.IsTrue(viewModel.SelectedItem.DataViewModel.Name == airportVM.DataViewModel.Name);


            //изменяем некоторое поле модели текущего элеменета. 
            //Эти изменения должны отобразиться 
            //в текущем представлении при обновлении
            //и при этом создадим новый элемент
            model.DeleteItems(new List<IItemModelAdapter<IEventModel>>() { airportVM.GetItemModel() });
            var newAirport = new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 18 min."));
            model.AddItems(new List<IItemModelAdapter<IEventModel>>() { newAirport });
            viewModel.UpdateList();
            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name && 
                viewModel.CurrentVM.DataViewModel.Description == "Airport station. 15 min.");
            Assert.IsTrue(viewModel.SelectedItem.DataViewModel.Name == airportVM.DataViewModel.Name && 
                viewModel.SelectedItem.DataViewModel.Description == "Airport station. 18 min.");


            //делаем обновление и при этом приходят элементы, в которых нет текущего
            //конкретно удаляем этот элемент
            model.DeleteItems(new List<IItemModelAdapter<IEventModel>>() { newAirport });
            viewModel.UpdateList();

            //теперь нет выбранного, элемента
            //в идеале еще надо как-то проверить что вывелось сообщение, что элемент был удален
            Assert.IsTrue(viewModel.CurrentVM == null);
            Assert.IsTrue(viewModel.SelectedItem == null);
        }


        //тест когда приходит обновление списка, в момент редактирования элемента
        [TestMethod]
        public void UpdateWhenElementSelectedAndEditing()
        {
            Init();

            //выбираем текущий элемент
            viewModel.SelectedItem = airportVM;

            //вызваем редактирование этого элемента
            viewModel.CurrentVM.Edit();

            //делаем изменения
            model.DeleteItems(new List<IItemModelAdapter<IEventModel>>() { airportVM.GetItemModel() });
            var newAirport = new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 18 min."));
            model.AddItems(new List<IItemModelAdapter<IEventModel>>() { newAirport });

            //вызываем update
            viewModel.UpdateList();

            //изменения не отображаются во VM
            Assert.IsTrue(viewModel.CurrentVM.DataViewModel.Name == airportVM.DataViewModel.Name &&
    viewModel.CurrentVM.DataViewModel.Description == "Airport station. 15 min.");
        }


        //что происходит, когда приходит обновдение редактируемого списка
        [TestMethod]
        public void UpdateEditedList()
        {
            //создаем список с включенным атообновлением
            Init();

            //viewModel.
            //включаем редактирование списка
            viewModel.EditList();

            //добавляем пару элементов в список, через VM
            //(элементы могут и не иметь еще уникальных id'шников)
            viewModel.AddItem();
            viewModel.CurrentVM.DataViewModel.Name = "New Station From VM 1";
            viewModel.CurrentVM.Save();
            viewModel.AddItem();
            viewModel.CurrentVM.DataViewModel.Name = "New Station From VM 2";
            viewModel.CurrentVM.Save();

            //удаляем один из элементов через VM
            var ivanovoVM = viewModel.ItemsVM.First(itm => itm.DataViewModel.Name == "Ivanovo");
            viewModel.DeleteItem(ivanovoVM);

            //добавлем в список-модель новый элемент
            var newItem = new ItemModelAdapterForPassive<IEventModel>(new EventModel(999853, "New Station From Model", DateTime.Now, ""));
            model.AddItems(new List<IItemModelAdapter<IEventModel>>() { newItem });

            //удаляем из списка-модели какой-нибудь старый элемент
            model.DeleteItems(new List<IItemModelAdapter<IEventModel>>() { airportVM.GetItemModel() });

            //вызываем обновление
            viewModel.UpdateList();

            //элементы, добавленные через VM-список остаются на месте
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From VM 1"));
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From VM 2"));
            //удаленные, остаются удаленными
            Assert.IsFalse(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "Ivanovo"));

            //и + мы видим все обновления, добавленные через список-модель
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From Model"));
            Assert.IsFalse(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "Airport"));



            //создаем новый список с отключенным автообновлением
            Init(false);

            //включаем редактирование списка
            viewModel.EditList();

            //добавляем пару элементов в список, через VM-списка
            //(элементы могут и не иметь еще уникальных id'шников)
            viewModel.AddItem();
            viewModel.CurrentVM.DataViewModel.Name = "New Station From VM 1";
            viewModel.CurrentVM.Save();
            viewModel.AddItem();
            viewModel.CurrentVM.DataViewModel.Name = "New Station From VM 2";
            viewModel.CurrentVM.Save();

            //удаляем один из элементов через VM
            ivanovoVM = viewModel.ItemsVM.First(itm => itm.DataViewModel.Name == "Ivanovo");
            viewModel.DeleteItem(ivanovoVM);

            //добавлем в список-модель новый элемент
            newItem = new ItemModelAdapterForPassive<IEventModel>(new EventModel(999853, "New Station From Model", DateTime.Now, ""));
            model.AddItems(new List<IItemModelAdapter<IEventModel>>() { newItem });

            //удаляем из списка-модели какой-нибудь старый элемент
            model.DeleteItems(new List<IItemModelAdapter<IEventModel>>() { airportVM.GetItemModel() });

            //вызываем обновление
            viewModel.UpdateList();

            //элементы, добавленные через VM-список остаются на месте
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From VM 1"));
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From VM 2"));
            //удаленные, остаются удаленными
            Assert.IsFalse(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "Ivanovo"));

            //изменения из модель-списка не доходят
            Assert.IsFalse(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "New Station From Model"));
            Assert.IsTrue(viewModel.ItemsVM.Any(itm => itm.DataViewModel.Name == "Airport"));
        }
    }
}
