using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace hospital.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private MyOption[] _myOptions = {
            new MyOption { Id = 1, Name = "carlos" },
            new MyOption { Id = 2, Name = "mario" },
            new MyOption { Id = 3, Name = "elon" },
            new MyOption { Id = 4, Name = "hideo" },
            new MyOption { Id = 6, Name = "joseph" }
        };
        public MyOption[] MyOptions
        {
            get { return _myOptions; }
            set { _myOptions = value; OnPropertyChanged(); }
        }

        private MyOption _selectedOption;
        public MyOption SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

