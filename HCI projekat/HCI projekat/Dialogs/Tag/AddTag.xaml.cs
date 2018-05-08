using HCI_projekat.Models;
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

namespace HCI_projekat.Dialogs.Tag
{
    /// <summary>
    /// Interaction logic for AddTag.xaml
    /// </summary>
    public partial class AddTag : Window
    {
        public ResourceTag tagObject
        {
            get;
            set;
        }
        public ResourceTag originalTag = null;

        #region Constructors
        //ovaj konstruktor se koristi kada se pravi prozor za dodavanje nove etikete
        public AddTag()
        {
            this.DataContext = this;    
            //ovde se mogu postaviti default vrednosti za polja
            tagObject = new ResourceTag { Color = "#FFFFFF" };
            InitializeComponent();
        }

        //ovaj konstuktor se poziva za uredjivanje postojece etikete
        public AddTag(ResourceTag tag)
        {
            this.DataContext = this;
            //kopira se prosledjena datoteka
            //ni slucajno tagObject = tag, onda kada korisnik menja nesto pa ne sacuva ostanu izmene
            tagObject = new ResourceTag { Id = tag.Id, Color = tag.Color, Description = tag.Description };
            //cuvamo prosledjeno da kada korisnik klikne sacuvaj mozemo izmeniti original
            originalTag = tag;
            InitializeComponent();
        }
        #endregion

        #region Commands
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if(originalTag is null)
            {
                //ovde se udje kada je kreirana nova etiketa
                Database.getInstance().ResourceTags.Add(tagObject);
            }
            else
            {
                //ovde se udje kada je menjana stara
                originalTag.Id = tagObject.Id;
                originalTag.Description = tagObject.Description;
                originalTag.Color = tagObject.Color;
            }
            this.Close();
        }
        #endregion
    }


}
