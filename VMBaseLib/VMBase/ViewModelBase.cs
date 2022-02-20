using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace VMBaseLib.VMBase
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string PropName = null)
        {
            var temp = Volatile.Read(ref PropertyChanged);

            temp?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }

        public bool Set<T>(ref T field, T value, string PropName)
        {
            if (field.Equals(value))
            {
                return false;
            }
            else
            {
                field = value;

                OnPropertyChanged(PropName);

                return true;
            }
        }
    }
}
