using HCI_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace HCI_projekat.Serialization
{
    class SaveAndOpen
    {

        public void save(String path, Database db)
        {
            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(db.GetType(), null, 0x7FFF, false, true, null);
                ser.WriteObject(fs, db);
                fs.Close();
            } 
        }

        public void open(String path)
        {
            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Database));
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());               
                Database db = (Database)ser.ReadObject(reader);
                Database.setInstance(db);

                fs.Close();
            }
        }

    }
}
