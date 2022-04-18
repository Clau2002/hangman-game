using Hangman.Model;
using Hangman.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly Player _player;
        //private readonly NavigationStore _navigationStore;

        //public App()
        //{
        //    _player = new Player();
        //    _navigationStore = new NavigationStore();
        //}

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    _navigationStore.CurrentViewModel = new LoginViewModel();

        //    MainWindow = new MainWindow()
        //    {
        //        DataContext = new MainViewModel(_navigationStore)
        //    };
        //    MainWindow.Show();

        //    base.OnStartup(e);
        //}
    }
}
