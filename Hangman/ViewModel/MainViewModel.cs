using Hangman.Commands;
using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Hangman.Services;

namespace Hangman.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Player> Players { get; set; }
        private string path = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Files\PlayersFile.txt";
        private string[] _players;
        public List<string> paths;
        private CurrentPlayer _currentPlayer;
        private string newPlayer;
        private Player _selectedPlayer;
        private object _currentView;

        private ICommand addPlayerCommand;
        private ICommand deletePlayerCommand;
        private ICommand changeViewCommand;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Players = new ObservableCollection<Player>();
            paths = new List<string>();
            paths.Add("Images/images.jpg");
            paths.Add("Images/hangman.png");
            _players = File.ReadAllLines(path);

            foreach (string name in _players)
            {
                Players.Add(new Player(name));
            }

            _currentPlayer = new CurrentPlayer(_selectedPlayer);
        }

        
        public string NewPlayer
        {
            get { return newPlayer; }
            set
            {
                if (newPlayer == value) return;
                newPlayer = value;
                NotifyPropertyChanged("NewPlayer");
            }
        }

        
        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                if (_selectedPlayer == value) return;
                _selectedPlayer = value;
                NotifyPropertyChanged("SelectedPlayer");
            }
        }

        private void DeletePlayer(object parameter)
        {
            if (SelectedPlayer != null)
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                lines.RemoveAt(Players.IndexOf(SelectedPlayer));
                Players.Remove(SelectedPlayer);
                File.WriteAllLines(path, lines.ToArray());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't selected a player!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void AddPlayer(object parameter)
        {
            Players.Add(new Player(newPlayer));

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(newPlayer);
            }

            newPlayer = "";
            OnPropertyChanged(nameof(newPlayer));
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public GameViewModel GameVM { get; set; }

        private void ChangeView(object parameter)
        {
            GameVM = new GameViewModel(SelectedPlayer.Username);
            CurrentView = GameVM;
        }

        public RelayCommand GameViewCommand { get; set; }

        public ICommand AddPlayerCommand
        {
            get
            {
                if (addPlayerCommand == null)
                    addPlayerCommand = new RelayCommand(AddPlayer);
                return addPlayerCommand;
            }
        }        

        public ICommand DeletePlayerCommand
        {
            get
            {
                if (deletePlayerCommand == null)
                    deletePlayerCommand = new RelayCommand(DeletePlayer);
                return deletePlayerCommand;
            }
        }        

        public ICommand ChangeViewCommand
        {
            get
            {
                if (changeViewCommand == null)
                    changeViewCommand = new RelayCommand(ChangeView);
                return changeViewCommand;
            }
        }       

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        return true;
        //    }

        //    return false;
        //}

        //public System.Windows.Media.ImageSource NewImagePath
        //{
        //    get => newImagePath;
        //    set => SetProperty(ref newImagePath, value);
        //}
    }
}
