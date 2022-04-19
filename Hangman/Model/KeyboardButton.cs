using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hangman.Model
{
    class KeyboardButton : INotifyPropertyChanged
    {
        private string _letter;

        public string Letter
        {
            get { return _letter; }
            set
            {
                _letter = value;
                NotifyPropertyChanged(nameof(Letter));
            }
        }

        private bool _visibility;

        public bool Button_Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                NotifyPropertyChanged(nameof(Button_Visibility));
            }
        }

        public KeyboardButton(string letter, bool visibility)
        {
            Letter = letter;
            Button_Visibility = visibility;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
