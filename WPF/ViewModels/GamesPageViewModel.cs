using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Helpers;
using DBLayer;
using DBLayer.Create;
using System.Windows;

namespace WPF.ViewModels
{
    public class GamesPageViewModel : BaseViewModel
    {
        Game gameBeingAddedToDB = new Game();
        CreateGame CreateGameInstance = new CreateGame();

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        private int _payout;
        public int payout
        {
            get { return _payout; }
            set
            {
                _payout = value;
                OnPropertyChanged("payout");
            }
        }

        private ICommand _navigateToHomePageCommand;
        public ICommand navigateToHomePageCommand
        {
            get
            {
                if (_navigateToHomePageCommand == null)
                {
                    _navigateToHomePageCommand = new Command(navigateToHomePage, canNavigateToHomePage);
                }
                return _navigateToHomePageCommand;
            }
            set { _navigateToHomePageCommand = value; }
        }

        public bool canNavigateToHomePage()
        {
            return true;
        }

        public void navigateToHomePage()
        {
            MainWindowViewModel windowViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel;
            windowViewModel.page = "MainPage.xaml";
        }

        //Add game to db

        private ICommand _addGameCommand;
        public ICommand addGameCommand
        {
            get
            {
                if (_addGameCommand == null)
                {
                    _addGameCommand = new Command(addGame, canAddGame);
                }
                return _addGameCommand;
            }
            set { _addGameCommand = value; }
        }

        public bool canAddGame()
        {
            return true;
        }

        // add functionality to check if the ID exists in db - only allow adding new user if the ID doesnt exist in DB
        public void addGame()
        {
            gameBeingAddedToDB.name = name;
            gameBeingAddedToDB.payout = payout;

            CreateGameInstance.CreateGameMethod(gameBeingAddedToDB);
            MessageBox.Show("Game succesfully added");
        }





    }
}
