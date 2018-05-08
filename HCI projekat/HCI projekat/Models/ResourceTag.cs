using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace HCI_projekat.Models
{
    // odradjeno sve sem metode koju ocekujem da se generise u nekom trenutku
    [DataContract]
    public class ResourceTag    :   INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String name)
        {
            if( PropertyChanged != null)
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

        // boja
        private string color;

        [DataMember]
        public string Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("ColorC");
                }
            }
        }

        public Color ColorC
        {
            get
            {
                if (color is null)
                    return Colors.HotPink;
                ColorConverter cc = new ColorConverter();
                return (Color)cc.ConvertFrom(color);
            }
            set
            {
                color = value.ToString();
                OnPropertyChanged("ColorC");
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
        #endregion
    }
}
