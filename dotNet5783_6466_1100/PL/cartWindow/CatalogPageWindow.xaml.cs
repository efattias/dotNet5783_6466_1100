using BO;
using MaterialDesignThemes.Wpf;
using PL.PO;
using PL.productWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for CatalogPageWindow.xaml
    /// </summary>
    public partial class CatalogPageWindow : Page
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        BO.Product? p = new BO.Product();
         public Cart cart = new Cart(){ CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };


        ObservableCollection<ProductItemPO>? productItemListPO = new();
        public CatalogPageWindow()
        {
            InitializeComponent();
            IEnumerableToObservable(bl.Product.getProductForList());
            pList.ItemsSource = productItemListPO;
            //productListV.DataContext = productListPO;


            //categorySelector.ItemsSource = Enum.GetValues(typeof(BO.Category));
        }

        private void IEnumerableToObservable(IEnumerable<ProductForList> listTOConvert)
        {
            productItemListPO.Clear();
            //productItemListPO = (from p in listTOConvert
            //                     let product = bl.Product.GetProductbyId(p.ID)
            //                     select new ProductItemPO()
            //                     {
            //                         ID = p.ID,
            //                         Name = p.Name,
            //                         Price = (double)p.Price,
            //                         Category = (PO.Category)p.Category,
            //                         Amount = (int)product.InStock
            //                     })

            foreach (var p in listTOConvert)
            {
                Product? product = bl!.Product.GetProductbyId(p.ID);
                bool inStockFlag;
                if(product.InStock>0)
                    inStockFlag = true;
                else
                    inStockFlag = false;

                ProductItemPO proPO = new ProductItemPO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = (double)p.Price,
                    Category = (PO.Category)p.Category,
                    InStock = inStockFlag,
                    Amount = (int)product.InStock
                };
                productItemListPO.Add(proPO);


            }
               
        }

        //private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (categorySelector.SelectedItem is BO.Category.הכל)
        //        IEnumerableToObservable(bl!.Product.getProductForList());
        //    else if (categorySelector.SelectedItem is BO.Category)
        //        IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category)categorySelector.SelectedItem));
        //    else if (categorySelector.SelectedItem is "")
        //        IEnumerableToObservable(bl!.Product.getProductForList());
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CartWindow caWindow = new CartWindow(cart);
            caWindow.Show();
        }

        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        
        {
            try
            {
                PO.ProductItemPO? product = ((Button)(sender)).DataContext as ProductItemPO ?? throw new NullReferenceException("כפתור לא מחזיר מוצר ");
               bl!.cart.AddProductToCart(cart, product.ID);
                MessageBox.Show("seccssed");
                //bl.cart.AddProductToCart(cart, p!.ID);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                IEnumerableToObservable(bl!.Product.getProductForList());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category.בישול)));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category.השכלה)));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category.נוער)));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category.ילדים)));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category.קודש)));
        }

        private void backToManager_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main=new MainWindow();
            main.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            RemoveGrouping_Click(sender, e);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(pList.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Name");
            SortDescription sortDscription = new SortDescription("Name", ListSortDirection.Ascending);
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(sortDscription);
            GroupByName.IsEnabled = false;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            RemoveGrouping_Click(sender, e);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(pList.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Price");
            SortDescription sortDscription = new SortDescription("Price", ListSortDirection.Ascending);
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(sortDscription);
            GroupByPrice.IsEnabled = false;
        }

        private void RemoveGrouping_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(pList.ItemsSource);
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productListPO);
            
            view.GroupDescriptions.Clear();
            view.SortDescriptions.Clear();

            GroupByPrice.IsEnabled = true;
            GroupByName.IsEnabled = true;

        }
    }
}
