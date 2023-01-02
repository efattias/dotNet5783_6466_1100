
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
using System.Windows.Shapes;

namespace PL.Cwindows;

/// <summary>
/// Interaction logic for productListWindow.xaml
/// </summary>
public partial class productListWindow : Window
{
    BlApi.IBL? bl = BlApi.Factory.GetBl() ??throw new NullReferenceException("Missing bl");
    // private IBL bl = Factory.GetBl();
    ObservableCollection<ProductForList> productList = new();

    public productListWindow()
    {
        InitializeComponent();
        IEnumerableToObservable(bl.Product.getProductForList());
        productListView.DataContext = productList;
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

    private void IEnumerableToObservable(IEnumerable<ProductForList> listTOConvert)
    {
        productList.Clear();
        foreach (var station in listTOConvert)
            productList.Add(station);
    }


    private void productListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new ProductWindow((BO.ProductForList)productListView.SelectedItem).Show();

    private void addP_Click(object sender, RoutedEventArgs e)
    {
  
            ProductWindow window = new ProductWindow();
            window.Show();
        
    }
    private void addTOList(BO.ProductForList product)
    {
        productList.Add(product);
    }













    // private void productListView_doubleClick(object sender, MouseButtonEventArgs e) => new ProductWindow((BO.ProductForList)productListView.SelectedItem).Show();

}