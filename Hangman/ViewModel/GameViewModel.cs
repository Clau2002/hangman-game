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

namespace Hangman.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private CurrentPlayer _currentPlayer;
        public ObservableCollection<ButtonsClass> ButtonsCollection { get; set; }
        private List<Button> _buttons;
        private List<BitmapImage> _hangmanImages;
        
        private string _imgPath;
        public string ImgPath
        {
            get;set;
        }

        //public Button Buttons
        //{
        //    get { return _buttons; }
        //}
        public int Stage { get; set; }

        //public BitmapImage ImageGen()
        //{
        //    for(int i = 1; i < 7; i++)
        //    {
        //        var image = new BitmapImage(new Uri(@"ms-appx:/Images/hangman"+i.ToString()+".png"));
        //        _hangmanImages.Add(image);
        //    }

        //    return _hangmanImages[Stage];
        //}

        //private BitmapImage initialImage;
        //public BitmapImage GetStageImage
        //{
        //    get { return new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "Images", "hangman" + ++Stage + ".png"))); }
        //    set
        //    {
        //        if (initialImage == value) return;
        //        initialImage = value;
        //        NotifyPropertyChanged(nameof(GetStageImage));
        //    }
        //} 

        public event PropertyChangedEventHandler PropertyChanged;

        public string _CurrentPlayer
        {
            get { return _currentPlayer.Username; }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string word;

        public string wordToGuess;
        public string WordToGuess { 
            get{ return wordToGuess; } 
            set 
            {
                if (wordToGuess == value) return;
                wordToGuess = value;
                NotifyPropertyChanged(nameof(WordToGuess));
            }
        }

        public string RandomWordGenerator()
        {
            string[] words = { "AUDI", "MERCEDES", "DACIA", "VOLVO", "FERRARI" };
            Random random = new Random();
            return words[random.Next(words.Length)];
        }

        public GameViewModel(string currentPlayer)
        {
            _buttons = new List<Button>();
            ButtonsCollection = new ObservableCollection<ButtonsClass>();
            _currentPlayer = new CurrentPlayer(new Player(currentPlayer));
            Stage = 1;
            //initialImage = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "Images", "hangman" + Stage + ".png")));
            word = RandomWordGenerator();
            //wordToGuess = word;
            wordToGuess = new string('*', word.Length);
            ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman"+ Stage +".png";
            for (int i = 65; i < 91; i++)
            {
                ButtonsClass buttonsClass = new ButtonsClass(((char)i).ToString(), true);
                ButtonsCollection.Add(buttonsClass);
                NotifyPropertyChanged(nameof(ButtonsCollection));
            }
            //TestFct();
        }

        private string test;
        public string Test
        {
            get { return test; }
            set
            {
                if (test == value) return;
                test = value;
                NotifyPropertyChanged("Test");
            }
        }

        public void TestFct(object param)
        {
            bool found = false;
            char index_chr = '-';
            int counter = 0;
            //Stage = 1;

            foreach (var item in word)
            {
               // counter = 0;
                if (item.ToString() == ButtonsCollection.ToList().Find(e => e.Letter == param).Letter)
                {
                    found = true;
                    index_chr = item;
                    ButtonsCollection.ToList().Find(e => e.Letter == param).Button_Visibility = false;
                    char[] array = wordToGuess.ToCharArray();
                    array[counter] = index_chr;
                    wordToGuess = new string(array);
                    
                    NotifyPropertyChanged(nameof(WordToGuess));
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

            if(Stage == 6)
            {
                MessageBox.Show("Game Over boss");
                Stage = 1;
                ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman" + Stage + ".png";
                word = RandomWordGenerator();
                wordToGuess = new string('*', word.Length);
                NotifyPropertyChanged(nameof(ImgPath));
                NotifyPropertyChanged(nameof(WordToGuess));
            }
            //if (counter == 1)
            //    ButtonsCollection.ToList().Find(e => e.Letter == param).Button_Visibility = false;
            //else
            //{
            //    while (counter > 1)
            //    {
            //        //ButtonsCollection.ToList().Find(e => e.Letter == param).Button_Visibility = true;
            //        counter--;
            //    }
            //}

            //if (found)
            //{
            //    ButtonsCollection.ToList().Find(e=>e.Letter==param).Button_Visibility = false;
            //    char[] array = wordToGuess.ToCharArray();
            //    array[word.IndexOf(index_chr)] = index_chr;
            //    wordToGuess = new string(array);
            //    NotifyPropertyChanged(nameof(WordToGuess));
            //}
        }

        private ICommand testCommand;

        public ICommand TestCommand
        {
            get
            {
                if (testCommand == null)
                    testCommand = new RelayCommand(TestFct);
                return testCommand;
            }
        }

        public void Reset(object parameter)
        {
            foreach (var item in ButtonsCollection)
            {
                item.Button_Visibility = true;
                word = RandomWordGenerator();
                wordToGuess = new string('*', word.Length);
                ImgPath = @"C:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\hangman1.png";
                Stage = 1;
                NotifyPropertyChanged(nameof(Stage));
                NotifyPropertyChanged(nameof(ImgPath));
                NotifyPropertyChanged(nameof(WordToGuess));
            }
        }

        private ICommand resetCommand;

        public ICommand ResetCommand
        {
            get
            {
                if (resetCommand == null)
                    resetCommand = new RelayCommand(Reset);
                return resetCommand;
            }
        }

        public string RandomWord
        {
            get { return WordToGuess; }
        }
    }
}
