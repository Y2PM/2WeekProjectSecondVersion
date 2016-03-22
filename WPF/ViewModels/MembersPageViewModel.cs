using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Helpers;
using DBLayer;
using DBLayer.Read;
using System.Collections.ObjectModel;

namespace WPF.ViewModels
{
    public class MembersPageViewModel : BaseViewModel
    {
        ReadMember ReadMemberInstance = new ReadMember();

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

        private int _member_ID;
        public int member_ID
        {
            get { return _member_ID; }
            set
            {
                _member_ID = value;
                OnPropertyChanged("member_ID");
            }
        }



        //<summary>
        //view member
        //</summary>

        private ObservableCollection<Member> _member;
        public ObservableCollection<Member> member
        {
            get { return _member; }
            set
            {
                _member = value;
                OnPropertyChanged("member");
            }
        }

        private ICommand _readMemberByIDCommand;
        public ICommand readMemberByIDCommand
        {
            get
            {
                if (_readMemberByIDCommand == null)
                {
                    _readMemberByIDCommand = new Command(readMemberByID, canReadMemberById);
                }
                return _readMemberByIDCommand;
            }
            set { _readMemberByIDCommand = value; }
        }

        public bool canReadMemberById()
        {
            return true;
        }

        public void readMemberByID()
        {
            Member memberReturned = ReadMemberInstance.ReadSpecificMember(member_ID);
            List<Member> memberList = new List<Member>();
            memberList.Add(memberReturned);
            member = new ObservableCollection<Member>(memberList);
        }

        //<summary>
        //view members
        //</summary>

        private ObservableCollection<Member> _members;
        public ObservableCollection<Member> members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged("members");
            }
        }

        private ICommand _readAllMembersCommand;
        public ICommand readAllMembersCommand
        {
            get
            {
                if (_readAllMembersCommand == null)
                {
                    _readAllMembersCommand = new Command(readAllMembers, canReadAllMembers);
                }
                return _readAllMembersCommand;
            }
            set { _readAllMembersCommand = value; }
        }

        public bool canReadAllMembers()
        {
            return true;
        }

        public void readAllMembers()
        {
            List<Member> listFromReadAllMembers = new List<Member>();
            listFromReadAllMembers = ReadMemberInstance.ReadAllMembers();
            members = new ObservableCollection<Member>(listFromReadAllMembers);
        }


    }
}
