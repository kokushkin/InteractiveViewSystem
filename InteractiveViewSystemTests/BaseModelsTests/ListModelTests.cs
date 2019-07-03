using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System.Collections.Generic;
using System.Linq;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;

namespace InteractiveViewSystemTests.BaseModelsTests
{
    [TestClass]
    public class ListModelTests
    {
        [TestMethod]
        public void AddItemsTest()
        {

            IListModel<IEventModel> model = new ListModel<IEventModel>();

            List<IItemModelAdapter<IEventModel>> items = new List<IItemModelAdapter<IEventModel>>();

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(235235, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 15 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(124590, "Lake", DateTime.Now, "Lake station. 5 min. Temporarily closed.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(744935, "Central station.", DateTime.Now, "Central station. 7 min.")));

            model.AddItems(items);

            var addedEvents = model.GetItems();

            Assert.IsTrue(items.Count == addedEvents.Count());
        }

        [TestMethod]
        public void DeleteItemsTest()
        {
            IListModel<IEventModel> model = new ListModel<IEventModel>();

            List<IItemModelAdapter<IEventModel>> items = new List<IItemModelAdapter<IEventModel>>();

            ItemModelAdapterForPassive<IEventModel> ivanovo = new ItemModelAdapterForPassive<IEventModel>(new EventModel(235235, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min."));
            items.Add(ivanovo);

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 15 min.")));

            ItemModelAdapterForPassive<IEventModel> lake = new ItemModelAdapterForPassive<IEventModel>(new EventModel(124590, "Lake", DateTime.Now, "Lake station. 5 min. Temporarily closed."));
            items.Add(lake);

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(744935, "Central station.", DateTime.Now, "Central station. 7 min.")));

            model.AddItems(items);

            List<IItemModelAdapter<IEventModel>> eventsForDelete = new List<IItemModelAdapter<IEventModel>>();
            eventsForDelete.Add(ivanovo);
            eventsForDelete.Add(lake);

            model.DeleteItems(eventsForDelete);

            var restOfEvents = model.GetItems();

            Assert.IsTrue(!restOfEvents.Contains(ivanovo) && !restOfEvents.Contains(lake));
        }

        [TestMethod]
        public void UpdateTest()
        {
            IListModel<IEventModel> model = new ListModel<IEventModel>();

            List<IItemModelAdapter<IEventModel>> items = new List<IItemModelAdapter<IEventModel>>();

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(235235, "Ivanovo", DateTime.Now, "Ivanovo station. 5 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(945853, "Airport", DateTime.Now, "Airport station. 15 min.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(124590, "Lake", DateTime.Now, "Lake station. 5 min. Temporarily closed.")));

            items.Add(new ItemModelAdapterForPassive<IEventModel>(new EventModel(744935, "Central station.", DateTime.Now, "Central station. 7 min.")));

            model.AddItems(items);

            List<IItemModelAdapter<IEventModel>> itemsFromUpdate = new List<IItemModelAdapter<IEventModel>>();

            model.Updated += (sender, e) =>
            {
                itemsFromUpdate.AddRange(e.List.GetItems());
            };

            model.Update();

            //множества совпадают
            Assert.IsTrue(items.Except(itemsFromUpdate).Count() == 0 && itemsFromUpdate.Except(items).Count() == 0);
        }
    }
}
