using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _page;
        public string page
        {
            get { return _page; }
            set
            {
                _page = value;
                OnPropertyChanged("page");
            }
        }

        public MainWindowViewModel()
        {
            page = "MainPage.xaml";
        }
    }
}
