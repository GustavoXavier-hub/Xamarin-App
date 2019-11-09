using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OficinaMVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Implementar OnPropertChange maior depois aula 08

        //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    var changed = PropertyChanged;
        //    if (changed == null)
        //        return;
        //    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //private bool isBusy = false;
        //public bool IsBusy
        //{
        //    get { return isBusy; }
        //    set { isBusy = value; OnPropertyChanged(); }
        //}


    }
}
