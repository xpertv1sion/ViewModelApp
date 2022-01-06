using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelApp.VM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public void Raise([CallerMemberName] string prop = "")
        {
            if (string.IsNullOrEmpty(prop))
                return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
