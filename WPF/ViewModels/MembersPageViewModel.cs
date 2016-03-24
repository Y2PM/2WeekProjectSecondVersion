using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Helpers;
using DBLayer;
using DBLayer.Read;
using DBLayer.Delete;
using DBLayer.Update;
using System.Collections.ObjectModel;
using WCFServiceCL;
using System.ServiceModel;

namespace WPF.ViewModels
{
    public class MembersPageViewModel : BaseViewModel
    {
        Member memberBeingSent = new Member();

        static EndpointAddress endpoint = new EndpointAddress("http://trnlon11675:8081/Service");
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11605:8081/Service");
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11566:8081/Service");
        IServe proxy = ChannelFactory<IServe>.CreateChannel(new BasicHttpBinding(), endpoint);

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

        private string _member_Name;
        public string member_Name
        {
            get { return _member_Name; }
            set
            {
                _member_Name = value;
                OnPropertyChanged("member_Name");
            }
        }

        private string _member_PW;
        public string member_PW
        {
            get { return _member_PW; }
            set
            {
                _member_PW = value;
                OnPropertyChanged("member_PW");
            }
        }

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
            Member memberReturned = proxy.ReadSpecificMemberServiceMethod(member_ID);
            List<Member> memberList = new List<Member>();
            memberList.Add(memberReturned);
            member = new ObservableCollection<Member>(memberList);
        }

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
            listFromReadAllMembers = proxy.ReadAllMembersServiceMethod();
            members = new ObservableCollection<Member>(listFromReadAllMembers);
        }

        private ICommand _deleteMemberCommand;
        public ICommand deleteMemberCommand
        {
            get
            {
                if (_deleteMemberCommand == null)
                {
                    _deleteMemberCommand = new Command(deleteMember, canDeleteMember);
                }
                return _deleteMemberCommand;
            }
            set { _deleteMemberCommand = value; }
        }

        public bool canDeleteMember()
        {
            return true;
        }

        public void deleteMember()
        {
            proxy.DeleteMemberServiceMethod(member_ID);
        }

        private ICommand _updateMemberCommand;
        public ICommand updateMemberCommand
        {
            get
            {
                if (_updateMemberCommand == null)
                {
                    _updateMemberCommand = new Command(updateMember, canUpdateMember);
                }
                return _updateMemberCommand;
            }
            set { _updateMemberCommand = value; }
        }

        public bool canUpdateMember()
        {
            return true;
        }

        public void updateMember()
        {
            memberBeingSent.member_id = member_ID;
            memberBeingSent.m_name = member_Name;
            memberBeingSent.m_password = member_PW;
            proxy.UpdateMemberServiceMethod(memberBeingSent);
        }

    }
}
