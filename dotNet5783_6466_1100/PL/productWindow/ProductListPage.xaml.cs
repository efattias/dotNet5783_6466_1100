using BO;
using PL.productWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl");
        // private IBL bl = Factory.GetBl();
        ObservableCollection<PO.ProductForListPO> productListPO = new();
        



        public ProductListPage()
        {
            InitializeComponent();
            //var listFromBo = bl.Product.getProductForList();
            //var listOfPO = (from o in listFromBo
            //                select new PO.ProductForListPO
            //                {
            //                    ID = o.ID,
            //                    Name = o.Name,
            //                    Price = (double)o.Price,
            //                    Category = (Category)o.Category
            //                }).ToList();

            IEnumerableToObservable(bl.Product.getProductForList()) ;
            productListV.DataContext = productListPO;
            //productListView.ItemsSource = bl.Product.getProductForList();
            categorySelector.ItemsSource = Enum.GetValues(typeof(BO.Category));
            // categorySelector.SelectedItem = BO.Category.All;
        }

        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (categorySelector.SelectedItem is BO.Category.הכל)
                IEnumerableToObservable(bl!.Product.getProductForList());
            else if (categorySelector.SelectedItem is BO.Category)
                IEnumerableToObservable(bl!.Product.GetPartOfProduct(p => p.Category == (BO.Category)categorySelector.SelectedItem));
            else if (categorySelector.SelectedItem is "")
                IEnumerableToObservable(bl!.Product.getProductForList());
        }   
        private void IEnumerableToObservable(IEnumerable<BO.ProductForList> listTOConvert)
        {
            var listPO = (from p in listTOConvert
                          select new PO.ProductForListPO
                          {
                              ID = p.ID,
                              Name = p.Name,
                              Price = (double)p.Price,
                              Category = (PO.Category)p.Category,
                              Path=p.Path
                              
                          }).ToList();
            productListPO.Clear();
            foreach (var p in listPO)
                productListPO.Add(p);

        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow(addProductToOB);
            window.ShowDialog();
          //  IEnumerableToObservable(productListPO);
        }

        private void doubleClickUpdateProduct( object sender, MouseButtonEventArgs e)
        {
            var product=(PO.ProductForListPO)productListV.SelectedItem;
            new ProductWindow(addProductToOB, product).ShowDialog();
            //PO.ProductForListPO? pPo = productListPO.FirstOrDefault(p => p.ID == product.ID);
            //BO.Product? pBO = bl!.Product.GetProductbyId(product.ID);
            //pPo!.ID = pBO.ID;
            //pPo.Name = pBO.Name;
            //pPo.Price = (double)pBO.Price;
            //pPo.Category = (Category)(pBO.Category);          
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CartWindow caWindow = new CartWindow();
            //caWindow.ShowDialog();
        }

        public void addProductToOB(PO.ProductForListPO product) => productListPO.Add(product);

      private void DeleteProduct_Click(object sender, RoutedEventArgs e ) 
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you shur you want to delete the package?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (messageBoxResult is (MessageBoxResult.Yes))
            {
                try
                {
                    PO.ProductForListPO po = productListV.SelectedItem as PO.ProductForListPO;
                    int id = po.ID; 
                    bl.Product.DeledeProduct(id);
                    productListPO.Remove(po);
                    categorySelector.SelectedItem = " ";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }

            }

        }

     
    }



}
