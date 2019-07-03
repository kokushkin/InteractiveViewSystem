using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.BaseModels;

namespace InteractiveViewSystemTests.BaseModelsTests
{
    /// <summary>
    /// Сводное описание для ItemModelTests
    /// </summary>
    [TestClass]
    public class ItemModelTests
    {

        [TestMethod]
        public void SaveTest()
        {
            string firstDescription = "Ivanovo station. 5 min.";

            string changedDescription = "Ivanovo station. 10 min.";

            string changedName = "Ivanovo3";

            IEventModel dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            IItemModel<IEventModel> model = new ItemModel<IEventModel>(dataModel);

            IEventModel dataModelFromUpdate = null;

            model.Updated += (sender, e) =>
                {
                    dataModelFromUpdate = e.Item.DataModel;
                };

            EventModel saveDataModel = new EventModel(23523, changedName, DateTime.Now, changedDescription);

            IItemModel<IEventModel> saveModel = new ItemModel<IEventModel>(saveDataModel);

            model.Save(saveModel);

            Assert.IsTrue(dataModelFromUpdate.Name == changedName);
            Assert.IsTrue(dataModelFromUpdate.Description == changedDescription);

            Assert.IsTrue(model.DataModel.Name == changedName);
            Assert.IsTrue(model.DataModel.Description == changedDescription);
        }


        [TestMethod]
        public void UpdateTest()
        {
            string firstDescription = "Ivanovo station. 5 min.";

            string changedDescription = "Ivanovo station. 10 min.";

            IEventModel dataModel = new EventModel(23523, "Ivanovo", DateTime.Now, firstDescription);

            IItemModel<IEventModel> model = new ItemModel<IEventModel>(dataModel);

            string changedDescriptionFromUpdated = String.Empty;

            model.Updated += (sender, e) =>
            {
                changedDescriptionFromUpdated = e.Item.DataModel.Description;
            };

            dataModel.Description = changedDescription;

            model.Update();

            Assert.IsTrue(changedDescription == changedDescriptionFromUpdated);
        }

        [TestMethod]
        public void UpdateTestWhenDataModelGetNewStateWithUpdate()
        {

            int oldCount = 34;

            ITestDataModel dataModel = new TestDataModel("NoName", oldCount);

            IItemModel<ITestDataModel> model = new ItemModel<ITestDataModel>(dataModel);

            int newCount = 0;

            model.Updated += (sender, e) =>
            {
                newCount = e.Item.DataModel.Count;
            };

            model.Update();

            Assert.IsTrue(newCount == oldCount + 1);

        }
    }
}
