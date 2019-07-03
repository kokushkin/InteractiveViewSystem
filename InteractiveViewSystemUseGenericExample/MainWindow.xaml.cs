using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystemUseGenericExample.Creators;
using InteractiveViewSystemUseGenericExample.Creators.SepareteShopModelEndViewModelCreator;
using InteractiveViewSystemUseGenericExample.Models;
using InteractiveViewSystemUseGenericExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveViewSystemUseGenericExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public IListViewModel<ShopModel, ShopViewModel, ShopDetailViewModel> ShopsTop { get; set; }

        public IListViewModel<ShopModel, ShopViewModel, ShopDetailViewModel> ShopsBottom { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ShopModel FishAndMeatShop = new ShopModel("FishAndMeat", "Oswin St, 3", "Very, very good");


            List<IItemModelAdapter<ProductModel>> fishAndMeatItems = new List<IItemModelAdapter<ProductModel>>();

            fishAndMeatItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Milk", 5, 4.56)));

            fishAndMeatItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Mushroom", 5, 9.88)));

            fishAndMeatItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Chicken", 2, 6.17)));

            fishAndMeatItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Soup", 3, 2.34)));

            fishAndMeatItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Cheese", 7, 3.96)));

            FishAndMeatShop.AddItems(fishAndMeatItems);




            ShopModel PenAndAppleShop = new ShopModel("PenAndApple", "Rushworth St, 34", "Super shop");


            List<IItemModelAdapter<ProductModel>> PenAndAppleItems = new List<IItemModelAdapter<ProductModel>>();

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Milk", 10, 5.56)));

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Wieners", 4, 4.38)));

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Chicken", 3, 5.22)));

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Fish", 2, 4.55)));

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Bread", 5, 1.24)));

            PenAndAppleItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Сhips", 3, 4.21)));

            PenAndAppleShop.AddItems(PenAndAppleItems);




            ShopModel GoodFoodShop = new ShopModel("GoodFood", "Scott Lidgett Cres, 24", "Sale everytime");


            List<IItemModelAdapter<ProductModel>> goodFoodItems = new List<IItemModelAdapter<ProductModel>>();

            goodFoodItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Milk", 4, 3.55)));

            goodFoodItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Mushroom", 5, 9.88)));

            goodFoodItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Wine", 2, 3.23)));

            goodFoodItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Soup", 5, 3.88)));

            goodFoodItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Bread", 3, 4.66)));

            GoodFoodShop.AddItems(goodFoodItems);




            ShopModel _7DaysShop = new ShopModel("7Days", "Plough Way, 55", "Open everytime");


            List<IItemModelAdapter<ProductModel>> _7DaysShopItems = new List<IItemModelAdapter<ProductModel>>();

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Milk", 2, 4.55)));

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Wieners", 10, 5.32)));

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Chicken", 2, 5.66)));

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Сhips", 5, 2.10)));

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Soup", 4, 5.24)));

            _7DaysShopItems.Add(new ItemModelAdapterForPassive<ProductModel>(new ProductModel("Cheese", 2, 4.33)));

            _7DaysShop.AddItems(_7DaysShopItems);


            IListModel<ShopModel> shopsModel= new ListModel<ShopModel>();

            List<IItemModelAdapter<ShopModel>> shops = new List<IItemModelAdapter<ShopModel>>();

            shops.Add(new ItemModelAdapterForPassive<ShopModel>(FishAndMeatShop));

            shops.Add(new ItemModelAdapterForPassive<ShopModel>(PenAndAppleShop));

            shops.Add(new ItemModelAdapterForPassive<ShopModel>(GoodFoodShop));

            shops.Add(new ItemModelAdapterForPassive<ShopModel>(_7DaysShop));

            shopsModel.AddItems(shops);


            var shopCreator = new ViewModelShopCreator();
            var shopModelCreator = new ShopModelAdapterCreator();

            var vmList = new ListViewModelWithTimer<ShopModel, ShopViewModel, ShopDetailViewModel>(shopsModel, shopCreator, shopModelCreator, 10);
            //var vmList = new ListViewModel<ShopModel, ShopViewModel, ShopDetailViewModel>(shopsModel, shopCreator, shopModelCreator);
            vmList.LetUpdate = true;
            ShopsTop = vmList;

            vmList = new ListViewModelWithTimer<ShopModel, ShopViewModel, ShopDetailViewModel>(shopsModel, shopCreator, shopModelCreator, 10);
            vmList.LetUpdate = true;
            ShopsBottom = vmList;

            this.DataContext = this;
        }


    }
}
