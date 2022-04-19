using Hangman.Commands;
using Hangman.Model;
using Hangman.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Hangman.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private CurrentPlayer _currentPlayer;
        public ObservableCollection<KeyboardButton> ButtonsCollection { get; set; }

        private string _initialWord;
        private string _wordToGuess;
        private string _createKeyboard;

        private ICommand createKeyboardCommand;
        private ICommand newGameCommand;

        public int Stage { get; set; }

        public string ImgPath { get; set; }

        public string _CurrentPlayer { get { return _currentPlayer.Username; } }

        public string WordToGuess
        {
            get { return _wordToGuess; }
            set
            {
                if (_wordToGuess == value) return;
                _wordToGuess = value;
                NotifyPropertyChanged(nameof(WordToGuess));
            }
        }

        public string RandomWord
        {
            get { return WordToGuess; }
        }

        public string CreateKeyboard
        {
            get { return _createKeyboard; }
            set
            {
                if (_createKeyboard == value) return;
                _createKeyboard = value;
                NotifyPropertyChanged("Test");
            }
        }

        public GameViewModel(string currentPlayer)
        {
            ButtonsCollection = new ObservableCollection<KeyboardButton>();
            _currentPlayer = new CurrentPlayer(new Player(currentPlayer));
            Stage = 1;
            _initialWord = RandomWordGenerator();
            _wordToGuess = new string('*', _initialWord.Length);
            ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman" + Stage + ".png";

            for (int i = 65; i < 91; i++)
            {
                KeyboardButton buttonsClass = new KeyboardButton(((char)i).ToString(), true);
                ButtonsCollection.Add(buttonsClass);
                NotifyPropertyChanged(nameof(ButtonsCollection));
            }
        }

        public string RandomWordGenerator()
        {
            string[] words = { "AUDI", "MERCEDES", "DACIA", "VOLVO", "FERRARI", "RENAULT", "OPEL", "TESLA", "FORD", "ARO", "HONDA" };
            Random random = new Random();
            return words[random.Next(words.Length)];
        }

        public void KeyboardFunc(object param)
        {
            bool found = false;
            char index_chr = '-';
            int counter = 0;

            foreach (var item in _initialWord)
            {
                if (item.ToString() == ButtonsCollection.ToList().Find(e => e.Letter == param).Letter)
                {
                    found = true;
                    index_chr = item;
                    ButtonsCollection.ToList().Find(e => e.Letter == param).Button_Visibility = false;
                    char[] array = _wordToGuess.ToCharArray();
                    array[counter] = index_chr;
                    _wordToGuess = new string(array);

                    NotifyPropertyChanged(nameof(WordToGuess));
                }
                else
                {
                    ButtonsCollection.ToList().Find(e => e.Letter == param).Button_Visibility = false;
                }
                counter++;
            }

            if (found == false)
            {
                Stage++;
                ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman" + Stage + ".png";
                NotifyPropertyChanged(nameof(Stage));
                NotifyPropertyChanged(nameof(ImgPath));
            }

            if (_wordToGuess.Contains(_initialWord) && Stage < 6)
            {
                MessageBox.Show("Congrats!");
                foreach (var item in ButtonsCollection)
                {
                    item.Button_Visibility = true;
                    _initialWord = RandomWordGenerator();
                    _wordToGuess = new string('*', _initialWord.Length);
                    ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman1.png";
                    Stage = 1;
                    NotifyPropertyChanged(nameof(Stage));
                    NotifyPropertyChanged(nameof(ImgPath));
                    NotifyPropertyChanged(nameof(WordToGuess));
                }
            }

            if (Stage == 6)
            {
                MessageBox.Show("Game Over boss:(");
                foreach (var item in ButtonsCollection)
                {
                    item.Button_Visibility = true;
                    _initialWord = RandomWordGenerator();
                    _wordToGuess = new string('*', _initialWord.Length);
                    ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman1.png";
                    Stage = 1;
                    NotifyPropertyChanged(nameof(Stage));
                    NotifyPropertyChanged(nameof(ImgPath));
                    NotifyPropertyChanged(nameof(WordToGuess));
                }
            }
        }

        public void NewGame(object parameter)
        {
            foreach (var item in ButtonsCollection)
            {
                item.Button_Visibility = true;
                _initialWord = RandomWordGenerator();
                _wordToGuess = new string('*', _initialWord.Length);
                ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman1.png";
                Stage = 1;
                NotifyPropertyChanged(nameof(Stage));
                NotifyPropertyChanged(nameof(ImgPath));
                NotifyPropertyChanged(nameof(WordToGuess));
            }
        }

        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                    newGameCommand = new RelayCommand(NewGame);
                return newGameCommand;
            }
        }

        public ICommand CreateKeyboardCommand
        {
            get
            {
                if (createKeyboardCommand == null)
                    createKeyboardCommand = new RelayCommand(KeyboardFunc);
                return createKeyboardCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
