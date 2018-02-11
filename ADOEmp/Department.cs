using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace ADOEmp
{
    public class Department : INotifyPropertyChanged
    {
        private string _name;

        public string Name                                  //add new
        {
            get { return this._name; }                      //add new
            set                                             //add new
            {
                if (this._name != value)                    //add new
                {                                           ////add new
                    this._name = value;
                    this.NotifyPropertyChanged("Name");         //add new
                }
            }
        }

        public Department()
        { }

        public Department(string _name)
        {
            Name = _name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)          //add new
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return $"Dep {this.Name}";
        }

    }
}
