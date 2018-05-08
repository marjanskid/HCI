using HCI_projekat.Dialogs.Tag;
using HCI_projekat.Dialogs.Type;
using HCI_projekat.Models;
using HCI_projekat.Validation;
using Microsoft.Win32;
using System;
using System.Collections;
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

namespace HCI_projekat.Dialogs.Resources
{
    /// <summary>
    /// Interaction logic for AddResource.xaml
    /// </summary>
    public partial class AddResource : Window
    {
        public const string defaultTypePath = "E:/Fucks/III godina/6. semestar/HCI/Projekat/HCI2017PZ1.3CVRA31-2015/HCI projekat/HCI projekat/Resources/Icons/defaultResource.png";

        public bool idError;
        private bool nameError;
        private bool descriptionError;
        private bool publicError;

        public Resource resourceObject
        {
            get;
            set;
        }
        public ObservableCollection<ResourceType> Types { get => Database.getInstance().ResourceTypes; set => Console.WriteLine("Ne treba"); }

        public Resource originalResource = null;

        #region Constructors
        public AddResource()
        {
            this.DataContext = this;
            resourceObject = new Resource { Renewable = false, StrategicImportant = false, Exploitation = false, Date = DateTime.Today};
            
            InitializeComponent();

            typesComboBox.ItemsSource = Types;
        }
         
        public AddResource(Resource r)
        {
            this.DataContext = this;
            resourceObject = new Resource { Id = r.Id, Name = r.Name, Description = r.Description,
                                            IconPath = r.IconPath, Price = r.Price, Renewable = r.Renewable,
                                            StrategicImportant = r.StrategicImportant, Exploitation = r.Exploitation,
                                            Date = r.Date, UnitOfMeasure = r.UnitOfMeasure, Frequency = r.Frequency};

            
            originalResource = r;

            InitializeComponent();
            typesComboBox.ItemsSource = Types;
        }

        #endregion

        #region Page1 Commands  

        // next to Page2 progressButton
        private void page1ProgressButton2_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
        }

        // next to Page3 progessButton
        private void page1ProgressButton3_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;
        }

        // next to Page2
        private void buttonNext1_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
        }

        #endregion

        #region Page2 Commands


        // load resource icon
        private void loadIcon1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(dialog.FileName));
                resourceObject.IconPath = dialog.FileName;
            }
        }

        // reset resource icon - set default
        private void nullIcon_Click(object sender, RoutedEventArgs e)
        {
            // ovo je samo privremeno dok ne uvedem instancu klase da kupi popunjene podatke
            imgPhoto.Source = new BitmapImage(new Uri("E:/Fucks/III godina/6. semestar/HCI/Projekat/HCI2017PZ1.3CVRA31-2015/HCI projekat/HCI projekat/Resources/Icons/defaultResource.png"));
            resourceObject.IconPath = defaultTypePath;
        }

        // add new resource tag
        private void addNewTagButton_Click(object sender, RoutedEventArgs e)
        {
            AddTag tag = new AddTag();
            showNextWindow(tag);
        }

        // add new resource type
        private void addNewTypeButton_Click(object sender, RoutedEventArgs e)
        {
            AddType type = new AddType();
            showNextWindow(type);
        }

        // back to Page1
        private void buttonBack1_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
        }

        // back to Page1 progressButton
        private void page2ProgressButton1_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
        }

        // next to Page3 progessButton
        private void page2ProgressButton3_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;
        }

        // next to Page3
        private void buttonNext2_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;
        }

        #endregion

        #region Page3 Commands

        // back to Page2
        private void buttonBack2_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
        }

        // back to Page1 progressButton
        private void page3ProgressButton1_Click(object sender, RoutedEventArgs e)
        {
            Page3.Visibility = Visibility.Collapsed;
            Page1.Visibility = Visibility.Visible;
        }

        // back to Page2 progessButton
        private void page3ProgressButton2_Click(object sender, RoutedEventArgs e)
        {
            Page3.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
        }

        // save new resource
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (originalResource is null)
            {
                //ovde se udje kada je kreirana nova etiketa
                Database.getInstance().Resources.Add(resourceObject);
            }
            else
            {
                //ovde se udje kada je menjana stara
                originalResource.Id = resourceObject.Id;
                originalResource.Name = resourceObject.Name;
                originalResource.Description = resourceObject.Description;

                originalResource.Frequency = resourceObject.Frequency;
                originalResource.IconPath = resourceObject.IconPath;
                
                originalResource.Price = resourceObject.Price;
                originalResource.Renewable = resourceObject.Renewable;
                originalResource.StrategicImportant = resourceObject.StrategicImportant;

                originalResource.Exploitation = resourceObject.Exploitation;
                originalResource.UnitOfMeasure = resourceObject.UnitOfMeasure;
                
                originalResource.Date = resourceObject.Date;
                originalResource.Type = resourceObject.Type;
                originalResource.Tags = resourceObject.Tags;
                

            }
            this.Close();
        }
        #endregion

        #region Validation
        private void idTextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                idError = true;
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (idTextBox.Text.Length > 0)
                buttonSave.IsEnabled = true;
            else
                buttonSave.IsEnabled = false;
        }
        #endregion

        private void showNextWindow(Window w)
        {          
            w.ShowDialog();
        }

    }
}


