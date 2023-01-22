

using BO;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PL.productWindow
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.GetBl() ?? throw new NullReferenceException("Missing bl") ;
     
        //IBL bl =  Factory.GetBl();
        BO.Product? p= new BO.Product();
        PO.ProductForListPO? pPO= new PO.ProductForListPO();
        PO.ProductPO? productPO=new PO.ProductPO();
        string? path;    
            
        //   Cart cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };
        Action<PO.ProductForListPO> action;

        public ProductWindow(Action<PO.ProductForListPO> addToObserval , PO.ProductForListPO? updateP=null)
        {
            InitializeComponent();
        
         //   pPO = updateP;
            categoryComboBox.ItemsSource=Enum.GetValues(typeof(BO.Category));
            action = addToObserval;
            
            if (updateP != null)// update
            {
                pPO = updateP;
                DataContext = pPO;
                //DataContext = updateP ;
                addToButton.Visibility = Visibility.Hidden;
                p = bl.Product.GetProductbyId(updateP.ID);
                //pPO.ID = p.ID;
                //pPO.Name = p.Name;
                //pPO.Price = (double)p.Price;
                //pPO.Category= (PO.Category)p.Category;
                AmountOfItemTextBox.Text = p.InStock.ToString();
                //pPO.InStock = (int)p.InStock;
               // UpdateButton.DataContext = p;
                IDTextBox.IsEnabled = false;
               

                ////DataContext = productPO;
                // addToButton.Visibility = Visibility.Hidden;
                // p = bl.Product.GetProductbyId(updateP.ID);
                // productPO.ID = p.ID;
                // productPO.Name = p.Name;
                // productPO.Price = (double)p.Price;
                // productPO.Category= (BO.Category)p.Category;
                // productPO.InStock = (int)p.InStock;

                // DataContext = productPO ;


                // IDTextBox.IsEnabled = false;

                //  IDTextBox.Text = p!.ID.ToString();
                // NameTextBox.Text=p!.Name.ToString();
                // PriceTextBox.Text = p!.Price.ToString();
                // AmountOfItemTextBox.Text = p!.InStock.ToString();
                //categoryComboBox.SelectedItem=p!.Category;
            }
            else
            {
                DataContext = p;
                UpdateButton.Visibility = Visibility.Hidden;
                addToButton.DataContext=p;
            }
            
        }
        private void updateImage_Button(object sender, RoutedEventArgs e)// עדכון
        {
            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
            f.Filter = "Image Files(*.jpeg; *.jpg; *.png; *.gif; *.bmp)|*.jpeg; *.jpg; *.png; *.gif; *.bmp";
            // f.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
            //"|PNG Portable Network Graphics (*.png)|*.png" +
            //"|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
            //"|BMP Windows Bitmap (*.bmp)|*.bmp" +
            //"|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
            //"|GIF Graphics Interchange Format (*.gif)|*.gif";
            if (f.ShowDialog() == true)
            {

                productImage.Source = new BitmapImage(new Uri(f.FileName));
                String[] spearator = { "PL" };
                Int32 count = 2;
                // using the method
                String[] strlist = productImage.Source.ToString().Split(spearator, count,
                       StringSplitOptions.RemoveEmptyEntries);
                path = strlist[1];


            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //create the product
            try
            {
               if(pPO.Path== null ) 
                pPO.Path = path ;

                

                p!.ID = int.Parse(IDTextBox.Text);
                p!.Name = NameTextBox.Text;
                p!.InStock = int.Parse(AmountOfItemTextBox.Text);
                p!.Category = (BO.Category?)categoryComboBox.SelectedItem;
                p!.Price = double.Parse(PriceTextBox.Text);
                p.Path = path;
                
                bl!.Product.UpdateDetailProduct(p); 

                //pPO.ID=p.ID;
                //pPO.Name= p.Name;
                //pPO.Price = (double)p.Price;
                //pPO.Category= (BO.Category)p.Category;

                //DataContext= pPO ;
               

                Close();
                MessageBox.Show("המוצר עודכן בהצלחה");
            }
            catch (Exception x)
            { MessageBox.Show(x.Message); }
        }

        private void addToButton_Click(object sender, RoutedEventArgs e)
        {
            //create the product
            try
            {
                //p!.ID = int.Parse(IDTextBox.Text);
                //p!.Name = NameTextBox.Text;
                 p!.InStock = int.Parse(AmountOfItemTextBox.Text);
                p.Path = path;
                // p!.Category = (BO.Category?)categoryComboBox.SelectedItem;
                //p!.Price = double.Parse(PriceTextBox.Text);
                int id = bl!.Product.AddProduct(p);
                action(new PO.ProductForListPO()
                {
                    ID = id,
                    Name = p.Name,
                    Price = (double)p.Price,
                    Category = (PO.Category)p.Category,
                    Path=p.Path
                });     
                
                
               // BO.Product? productTemp = bl.Product.GetProductbyId(id);
                //PO.ProductForListPO pToReturn = new()
                //{
                //    Category = (Category)p.Category,
                //    Price = (double)p.Price,
                //    ID = id,
                //    Name = p.Name
                //  //  Path = p.Path
                //};
                
                
               

                Close();
                MessageBox.Show("המוצר הוסף בהצלחה");
            }
            catch (Exception x)
            { MessageBox.Show(x.Message); }
        }


       

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    bl.cart.AddProductToCart(cart, p!.ID);
        //    this.Close();

        //}
    }
}
