using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModelApp.VM
{
    public class MainViewModel : BaseViewModel
    {

        public string SavePath { get; set; } = "./config.xml";

        public string Header { get; set; }

        public int Number { get; set; }

        public ObservableCollection<ListViewModel> List { get; set; } = new ObservableCollection<ListViewModel>();

        internal MainViewModel LoadSettings()
        {
            if (!File.Exists(SavePath))
                return new MainViewModel();

            var xml = new XmlSerializer(typeof(MainViewModel));

            using (var fs = new FileStream(SavePath, FileMode.Open))
            {
                return (MainViewModel) xml.Deserialize(fs);
            }
        }

        internal void SaveSettings()
        {
            var xml = new XmlSerializer(typeof(MainViewModel));

            using (var fs = new FileStream(SavePath, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, this);
            }
        }
    }
}
