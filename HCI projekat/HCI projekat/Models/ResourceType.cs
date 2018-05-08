using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;

namespace HCI_projekat.Models
{
    // odradjeno sve sem metode koju ocekujem da se generise u nekom trenutku
    [DataContract]
    public class ResourceType : INotifyPropertyChanged
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
        #endregion
       
    }
}
