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


namespace Hangman.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Player> Players { get; set; }
        private string[] _players = System.IO.File.ReadAllLines(@"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Files\PlayersFile.txt");
        //private Player currentPlayer;
        //public Player CurrentPlayer
        //{
        //    get { return currentPlayer; }
        //    set
        //    {
        //        if (currentPlayer == value) return;
        //        currentPlayer = value;
        //        NotifyPropertyChanged("CurrentPerson");
        //    }
        //}

        public MainViewModel()
        {
            Players = new ObservableCollection<Player>();

            foreach (string name in _players)
            {
                Players.Add(new Player(name));
            }

            //GameVM = new GameViewModel();

            //GameViewCommand = new RelayCommand2(o =>
            //{
            //    CurrentView = GameVM;
            //});
        }

        private string newPlayer;
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

        private Player _selectedPlayer;
        public Player SelectedPlayer { 
            get { return _selectedPlayer; }
            set
            {
                if (_selectedPlayer == value) return;
                _selectedPlayer = value;
                NotifyPropertyChanged("SelectedPlayer");
            }
        }

        private void DeletePlayer()
        {
            if (SelectedPlayer != null)
            {
                List<string> lines = File.ReadAllLines(@"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Files\PlayersFile.txt").ToList();
                lines.RemoveAt(Players.IndexOf(SelectedPlayer));
                Players.Remove(SelectedPlayer);
                File.WriteAllLines((@"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Files\PlayersFile.txt"), lines.ToArray());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't selected a player!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void AddPlayer()
        {
            Players.Add(new Player(newPlayer));

            using (StreamWriter writer = File.AppendText(@"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Files\PlayersFile.txt"))
            {
                writer.WriteLine(newPlayer);
            }
        }

        private void ChangeView()
        {
            GameVM = new GameViewModel();
            CurrentView = GameVM;
        }

        private ICommand addPlayerCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddPlayerCommand
        {
            get
            {
                if (addPlayerCommand == null)
                    addPlayerCommand = new RelayCommand(AddPlayer);
                return addPlayerCommand;
            }
        }

        private ICommand deletePlayerCommand;

        public ICommand DeletePlayerCommand
        {
            get
            {
                if (deletePlayerCommand == null)
                    deletePlayerCommand = new RelayCommand(DeletePlayer);
                return deletePlayerCommand;
            }
        }

        private ICommand changeViewCommand;

        public ICommand ChangeViewCommand
        {
            get
            {
                if (changeViewCommand == null)
                    changeViewCommand = new RelayCommand(ChangeView);
                return changeViewCommand;
            }
        }

        public RelayCommand GameViewCommand { get; set; }

        //public RelayCommand2 GameViewCommand { get; set; }
        public GameViewModel GameVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
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
    }
}
