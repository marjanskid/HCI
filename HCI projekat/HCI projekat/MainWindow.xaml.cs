using HCI_projekat.Dialogs.Resources;
using HCI_projekat.Dialogs.Tag;
using HCI_projekat.Dialogs.Type;
using HCI_projekat.Models;
using HCI_projekat.Serialization;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HCI_projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        #region Attributes
        private const string showIconPath = "E:\\Fucks\\III godina\\6. semestar\\HCI\\Projekat\\HCI2017PZ1.3CVRA31-2015\\HCI projekat\\HCI projekat\\Resources\\Icons\\show_table.png";
        private const string mainIconPath = "E:\\Fucks\\III godina\\6. semestar\\HCI\\Projekat\\HCI2017PZ1.3CVRA31-2015\\HCI projekat\\HCI projekat\\Resources\\Icons\\icon.png";

        #endregion
        public MainWindow()
        {
            SaveAndOpen opener = new SaveAndOpen();
            opener.open(@"E:\Fucks\III godina\6. semestar\HCI\Projekat\HCI2017PZ1.3CVRA31-2015\HCI projekat\HCI projekat\Data\dusan.xml");
             
            InitializeComponent();

            ResourcesTable.ItemsSource = Database.getInstance().Resources;
            TypesTable.ItemsSource = Database.getInstance().ResourceTypes;
            TagsTable.ItemsSource = Database.getInstance().ResourceTags;

            showMenuButtons();
        }

        #region Commands
        private void AddResource_Executed(object sender, RoutedEventArgs e)
        {
            AddResource addResource = new AddResource();
            showNewWindow(addResource);
        }
        
        private void ShowResources_Executed(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Collapsed;
            ShowResources.Visibility = Visibility.Visible;
            setProp(showIconPath, "Prikaz postojećih resursa", this);
        }
       
        private void AddType_Executed(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            showNewWindow(addType);
        }

        private void ShowTypes_Executed(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Collapsed;
            ShowTypes.Visibility = Visibility.Visible;
            setProp(showIconPath, "Prikaz postojećih tipova resursa", this);
        }

        private void AddTag_Executed(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            showNewWindow(addTag);
        }

        private void ShowTags_Executed(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Collapsed;
            ShowTags.Visibility = Visibility.Visible;
            setProp(showIconPath, "Prikaz postojećih etiketa", this);
        }
        #endregion

        #region MenuButtons
        private void showMenuButtons()
        {
            // Inicijalizacija desnog menija
            desniMeniPrikaz.Visibility = Visibility.Hidden;
            //desniMeniSakriven.Visibility = Visibility.Visible;
            CloseMenu2.Visibility = Visibility.Hidden;
            OpenMenu2.Visibility = Visibility.Visible;

            // Inicijalizacija desnog menija
            leviMeniPrikaz.Visibility = Visibility.Hidden;
            //desniMeniSakriven.Visibility = Visibility.Visible;
            CloseMenu1.Visibility = Visibility.Hidden;
            OpenMenu1.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu1_Click(object sender, RoutedEventArgs e)
        {
            leviMeniPrikaz.Visibility = Visibility.Visible;
            //desniMeniSakriven.Visibility = Visibility.Hidden;
            CloseMenu1.Visibility = Visibility.Visible;
            OpenMenu1.Visibility = Visibility.Hidden;
        }

        private void ButtonCloseMenu1_Click(object sender, RoutedEventArgs e)
        {
            leviMeniPrikaz.Visibility = Visibility.Hidden;
            //desniMeniSakriven.Visibility = Visibility.Visible;
            CloseMenu1.Visibility = Visibility.Hidden;
            OpenMenu1.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu2_Click(object sender, RoutedEventArgs e)
        {
            desniMeniPrikaz.Visibility = Visibility.Visible;
            //desniMeniSakriven.Visibility = Visibility.Hidden;
            CloseMenu2.Visibility = Visibility.Visible;
            OpenMenu2.Visibility = Visibility.Hidden;
        }

        private void ButtonCloseMenu2_Click(object sender, RoutedEventArgs e)
        {
            desniMeniPrikaz.Visibility = Visibility.Hidden;
            //desniMeniSakriven.Visibility = Visibility.Visible;
            CloseMenu2.Visibility = Visibility.Hidden;
            OpenMenu2.Visibility = Visibility.Visible;
        }
        #endregion

        #region ShowResources
        private void buttonShowResourcesBack_Click(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Visible;
            ShowResources.Visibility = Visibility.Collapsed;
            setProp(mainIconPath, "Glavni meni", this);
        }

        private void buttonShowResourcesAdd_Click(object sender, RoutedEventArgs e)
        {
            AddResource addResource = new AddResource();
            showNewWindow(addResource);
        }

        private void buttonShowResourcesEdit_Click(object sender, RoutedEventArgs e)
        {
            Resource r = (Resource)ResourcesTable.SelectedValue;
            if (r != null)
            {
                AddResource window = new AddResource(r);
                showNewWindow(window);
            }
        }

        private void buttonShowResourcesDelete_Click(object sender, RoutedEventArgs e)
        {
            Resource r = (Resource)ResourcesTable.SelectedValue;
            if (r != null)
            {
                Database.getInstance().Resources.Remove(r);
            }
        }

        private void buttonShowResourcesSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonShowResourcesTypes_Click(object sender, RoutedEventArgs e)
        {
            ShowTypes.Visibility = Visibility.Visible;
            ShowResources.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih tipova resursa", this);
        }
        private void buttonShowResourcesTags_Click(object sender, RoutedEventArgs e)
        {
            ShowTags.Visibility = Visibility.Visible;
            ShowResources.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih etiketa", this);
        }
        #endregion

        #region ShowTypes
        private void buttonShowTypesBack_Click(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Visible;
            ShowTypes.Visibility = Visibility.Collapsed;
            setProp(mainIconPath, "Glavni meni", this);
        }

        private void buttonShowTypesAdd_Click(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            showNewWindow(addType);
        }

        private void buttonShowTypesEdit_Click(object sender, RoutedEventArgs e)
        {
            ResourceType rt = (ResourceType)TypesTable.SelectedValue;
            if (rt != null)
            {
                AddType window = new AddType(rt);
                showNewWindow(window);
            }
        }

        private void buttonShowTypesDelete_Click(object sender, RoutedEventArgs e)
        {
            ResourceType t = (ResourceType)TypesTable.SelectedValue;
            if (t != null)
            {
                Database.getInstance().ResourceTypes.Remove(t);
            }
        }

        private void buttonShowTypesSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonShowTypesResources_Click(object sender, RoutedEventArgs e)
        {
            ShowResources.Visibility = Visibility.Visible;
            ShowTypes.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih resursa", this);
        }
        private void buttonShowTypesTags_Click(object sender, RoutedEventArgs e)
        {
            ShowTags.Visibility = Visibility.Visible;
            ShowTypes.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih etiketa", this);
        }
        #endregion

        #region ShowTags
        private void buttonShowTagsBack_Click(object sender, RoutedEventArgs e)
        {
            Map.Visibility = Visibility.Visible;
            ShowTags.Visibility = Visibility.Collapsed;
            setProp(mainIconPath, "Glavni meni", this);
        }

        private void buttonShowTagsAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            showNewWindow(addTag);
        }

        private void buttonShowTagsEdit_Click(object sender, RoutedEventArgs e)
        {
            ResourceTag t = (ResourceTag)TagsTable.SelectedValue;
            if (t != null)
            {
                AddTag window = new AddTag(t);
                showNewWindow(window);
            }
        }

        private void buttonShowTagsDelete_Click(object sender, RoutedEventArgs e)
        {
            ResourceTag t = (ResourceTag)TagsTable.SelectedValue;
            if (t != null)
            {
                Database.getInstance().ResourceTags.Remove(t);
            }
        }

        private void buttonShowTagsSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonShowTagsResources_Click(object sender, RoutedEventArgs e)
        {
            ShowResources.Visibility = Visibility.Visible;
            ShowTags.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih resursa", this);
        }
        private void buttonShowTagsTypes_Click(object sender, RoutedEventArgs e)
        {
            ShowTypes.Visibility = Visibility.Visible;
            ShowTags.Visibility = Visibility.Collapsed;
            setProp(showIconPath, "Prikaz postojećih tipova resursa", this);
        }

        #endregion

        #region Other

        // set window size and show it
        private void showNewWindow(Window w)
        {
            w.Height = 0.8 * this.MaxHeight;
            w.Width = 0.8 * this.MaxWidth;
            w.ShowDialog();
        }

        // serialization
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveAndOpen saver = new SaveAndOpen();
            saver.save(@"E:\Fucks\III godina\6. semestar\HCI\Projekat\HCI2017PZ1.3CVRA31-2015\HCI projekat\HCI projekat\Data\dusan.xml", Database.getInstance());
        }

        // set window title and icon
        private void setProp(string iconPath, string title, Window window)
        {
            window.Title = title;
            Uri iconUri = new Uri(iconPath, UriKind.RelativeOrAbsolute);
            window.Icon = BitmapFrame.Create(iconUri);
        }

        #endregion
    }
}
