using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Helpers;
using DBLayer;
using DBLayer.Create;
using DBLayer.Read;
using DBLayer.Update;
using DBLayer.Delete;
using System.Windows;
using System.Collections.ObjectModel;
using WCFServiceCL;
using System.ServiceModel;

namespace WPF.ViewModels
{
    public class GamesPageViewModel : BaseViewModel
    {
        Game gameBeingSent = new Game();
        Game gameBeingAddedToDB = new Game();
        CreateGame CreateGameInstance = new CreateGame();
        ReadGame ReadGameInstance = new ReadGame();
        UpdateGame UpdateGameInstance = new UpdateGame();
        DeleteGame DeleteGameInstance = new DeleteGame();

        static EndpointAddress endpoint = new EndpointAddress("http://trnlon11605:8081/Service");
        IServe proxy = ChannelFactory<IServe>.CreateChannel(new BasicHttpBinding(), endpoint);

        private int _game_ID;
        public int game_ID
        {
            get { return _game_ID; }
            set
            {
                _game_ID = value;
                OnPropertyChanged("game_ID");
            }
        }

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

        public void addGame()
        {
            gameBeingAddedToDB.name = name;
            gameBeingAddedToDB.payout = payout;
            proxy.CreateGameServiceMethod(gameBeingAddedToDB);
            MessageBox.Show("Game succesfully added");
        }

        private ObservableCollection<Game> _game;
        public ObservableCollection<Game> game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged("game");
            }
        }

        private ICommand _readGameByIDCommand;
        public ICommand readGameByIDCommand
        {
            get
            {
                if (_readGameByIDCommand == null)
                {
                    _readGameByIDCommand = new Command(readGameByID, canReadGameById);
                }
                return _readGameByIDCommand;
            }
            set { _readGameByIDCommand = value; }
        }

        public bool canReadGameById()
        {
            return true;
        }

        public void readGameByID()
        {
            Game gameReturned = proxy.ReadSpecificGameServiceMethod(game_ID);
            List<Game> gameList = new List<Game>();
            gameList.Add(gameReturned);
            game = new ObservableCollection<Game>(gameList);
        }

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged("games");
            }
        }

        private ICommand _readAllGamesCommand;
        public ICommand readAllGamesCommand
        {
            get
            {
                if (_readAllGamesCommand == null)
                {
                    _readAllGamesCommand = new Command(readAllGames, canReadAllGames);
                }
                return _readAllGamesCommand;
            }
            set { _readAllGamesCommand = value; }
        }

        public bool canReadAllGames()
        {
            return true;
        }

        public void readAllGames()
        {
            List<Game> listFromReadAllGames = new List<Game>();
            listFromReadAllGames = proxy.ReadAllGamesServiceMethod();
            games = new ObservableCollection<Game>(listFromReadAllGames);
        }

        private ICommand _updateGameCommand;
        public ICommand updateGameCommand
        {
            get
            {
                if (_updateGameCommand == null)
                {
                    _updateGameCommand = new Command(updateGame, canUpdateGame);
                }
                return _updateGameCommand;
            }
            set { _updateGameCommand = value; }
        }

        public bool canUpdateGame()
        {
            return true;
        }

        public void updateGame()
        {
            gameBeingSent.game_id = game_ID;
            gameBeingSent.name = name;
            gameBeingSent.payout = payout;
            proxy.UpdateGameServiceMethod(gameBeingSent);

        }

        private ICommand _deleteGameCommand;
        public ICommand deleteGameCommand
        {
            get
            {
                if (_deleteGameCommand == null)
                {
                    _deleteGameCommand = new Command(deleteGame, canDeleteGame);
                }
                return _deleteGameCommand;
            }
            set { _deleteGameCommand = value; }
        }

        public bool canDeleteGame()
        {
            return true;
        }

        public void deleteGame()
        {
            proxy.DeleteGameServiceMethod(game_ID);
        }

    }
}
