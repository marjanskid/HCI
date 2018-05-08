using HCI_projekat.Models;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace HCI_projekat.Dialogs.Type
{
    /// <summary>
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        public const string defaultTypePath = "E:/Fucks/III godina/6. semestar/HCI/Projekat/HCI2017PZ1.3CVRA31-2015/HCI projekat/HCI projekat/Resources/Icons/defaultResource.png";
        public ResourceType typeObject
        {
            get;
            set;
        }
        public ResourceType originalType = null;

        #region Constructors
        //ovaj konstruktor se koristi kada se pravi prozor za dodavanje nove etikete
        public AddType()
        {
            this.DataContext = this;
            typeObject = new ResourceType { IconPath = defaultTypePath };
            InitializeComponent();
        }

        //ovaj konstuktor se poziva za uredjivanje postojece etikete
        public AddType(ResourceType rt)
        {
            this.DataContext = this;
            typeObject = new ResourceType { Id = rt.Id, Name = rt.Name, Description = rt.Description, IconPath = rt.IconPath};
            originalType = rt;
            InitializeComponent();
        }
        #endregion

        #region Commands
        private void loadIcon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(dialog.FileName));
                typeObject.IconPath = dialog.FileName;
            }
        }

        private void nullIcon_Click(object sender, RoutedEventArgs e)
        {
            imgPhoto.Source = null;
            // ovo je samo privremeno dok ne uvedem instancu klase da kupi popunjene podatke
            imgPhoto.Source = new BitmapImage(new Uri(defaultTypePath));
            typeObject.IconPath = defaultTypePath;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (originalType is null)
            {
                Database.getInstance().ResourceTypes.Add(typeObject);
            }
            else
            {
                originalType.Id = typeObject.Id;
                originalType.Name = typeObject.Name;
                originalType.Description = typeObject.Description;
                originalType.IconPath = typeObject.IconPath;
            }
            this.Close();
        }
        #endregion
    }
}
