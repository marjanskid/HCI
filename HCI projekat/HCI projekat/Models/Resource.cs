using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace HCI_projekat.Models
{
    [DataContract]
    public class Resource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #region Attributes
        // id
        private string id;

        [DataMember]
        public string Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        // name
        private string name;

        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        // opis
        private string description;

        [DataMember]
        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }


        // tip
        private ResourceType type;
        [DataMember]
        public ResourceType Type
        {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }


        // frekvencija pojavljivanja(redak, cest, univerzalan)
        private string frequency;
        [DataMember]
        public string Frequency
        {
            get { return frequency; }
            set
            {
                if (value != frequency)
                {
                    frequency = value;
                    OnPropertyChanged("Frequency");
                }
            }
        }


        // ikonica
        private string iconPath;
        [DataMember]
        public string IconPath
        {
            get { return iconPath; }
            set
            {
                if (value != iconPath)
                {
                    iconPath = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public BitmapImage Ikonica
        {
            get
            {
                if (iconPath == null)
                    return null;
                Uri uri = new Uri(@iconPath, UriKind.RelativeOrAbsolute);
                BitmapImage img = new BitmapImage(uri);
                return img;
            }

        }


        // obnovljiv/neobnovljiv
        private bool renewable;
        [DataMember]
        public bool Renewable
        {
            get { return renewable; }
            set
            {
                if (value != renewable)
                {
                    renewable = value;
                    OnPropertyChanged("Renewable");
                }
            }
        }


        // od strateske vaznosti/nije od strateske vaznosti
        private bool strategicImportant;
        [DataMember]
        public bool StrategicImportant
        {
            get { return strategicImportant; }
            set
            {
                if (value != strategicImportant)
                {
                    strategicImportant = value;
                    OnPropertyChanged("StrategicImportant");
                }
            }
        }


        // moze se eksploatisati/ne moze se eksploatisati
        private bool exploitation;
        [DataMember]
        public bool Exploitation
        {
            get { return exploitation; }
            set
            {
                if (value != exploitation)
                {
                    exploitation = value;
                    OnPropertyChanged("Exploitation");
                }
            }
        }


        // jedinica mere(merica, barel, tona, kilogram)
        private string unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set
            {
                if (value != unitOfMeasure)
                {
                    unitOfMeasure = value;
                    OnPropertyChanged("UnitOfMeasure");
                }
            }
        }


        // cena u dolarima
        private double price;
        [DataMember]
        public double Price
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }


        // datum otkrivanja
        private DateTime date;
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private ObservableCollection<ResourceTag> tags;
        [DataMember]
        public ObservableCollection<ResourceTag> Tags
        {
            get { return tags; }
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        #endregion

    }
}
