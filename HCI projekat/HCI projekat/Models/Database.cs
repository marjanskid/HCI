using HCI_projekat.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCI_projekat.Properties;
using System.Runtime.Serialization;

namespace HCI_projekat.Models
{
    [DataContract]
    public class Database 
    {
        #region Attributes
        private static Database instance = null;

        private ObservableCollection<Resource> resources;
        private ObservableCollection<ResourceType> resourceTypes;
        private ObservableCollection<ResourceTag> resourceTags;

        [DataMember]
        public ObservableCollection<Resource> Resources
        {
            get { return resources; }
            set
            {
                if (value != resources)
                {
                    resources = value;
                }
            }
        }

        [DataMember]
        public ObservableCollection<ResourceType> ResourceTypes
        {
            get { return resourceTypes; }
            set
            {
                if (value != resourceTypes)
                {
                    resourceTypes = value;
                }
            }
        }

        [DataMember]
        public ObservableCollection<ResourceTag> ResourceTags
        {
            get { return resourceTags; }
            set
            {
                if (value != resourceTags)
                {
                    resourceTags = value;
                }
            }
        }
        #endregion

        #region Singleton
        private Database()
        {
            resources = new ObservableCollection<Resource>();
            resourceTypes = new ObservableCollection<ResourceType>();
            resourceTags = new ObservableCollection<ResourceTag>();
        }

        public static Database getInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        public static void setInstance(Database db)
        {
            instance = db;
        }
        #endregion       
    }
}
