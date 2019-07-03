using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteractiveViewSystem.BaseModels;

namespace InteractiveViewSystemTests.BaseModelsTests
{

    public interface ITestDataModel : IItemDataModel<ITestDataModel>
    {
        string Name { get; set; }

        int Count { get; set; }
    }

    public class TestDataModel : ITestDataModel
    {
        public string Name { get; set; }

        public int Count { get; set; }


        public TestDataModel(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public void Save(ITestDataModel saveDataModel)
        {
            Name = saveDataModel.Name;
            Count = saveDataModel.Count;
        }

        public void Update()
        {
            Count++;
        }
    }

    [TestClass]
    public class IItemDataModelTest
    {
        [TestMethod]
        public void ITestDataModelCreateObject()
        {
            ITestDataModel dataModel = new TestDataModel("NoName", 34);

            dataModel.Update();
            Assert.IsTrue(dataModel.Count == 35);

            dataModel.Save(new TestDataModel("SimpleName", 24));
            Assert.IsTrue(dataModel.Name == "SimpleName" && dataModel.Count == 24);


        }
    }
}
