using FontAwesome.Sharp;
using Nhom_15.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Nhom_15.ViewModel
{
     class MainViewModel:ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private TaiKhoan _currentUserAccount;

        //private TaiKhoan _currentUserAccount;
        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public TaiKhoan CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ICommand ShowTrangChuViewCommand { get; }
        public ICommand ShowTheLoaiViewCommand { get; }
        public ICommand ShowYourMusicViewCommand { get; }
        public ICommand ShowDashboardViewCommand { get; }
        public MainViewModel()
        {
            CurrentUserAccount = DataProvider.Instance.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            ShowTrangChuViewCommand = new ViewModelCommand(ExecuteShowTrangChuViewCommand);
            ShowTheLoaiViewCommand = new ViewModelCommand(ExecuteShowTheLoaiViewCommand);
            ShowYourMusicViewCommand = new ViewModelCommand(ExecuteShowYourMusicViewCommand);
            ShowDashboardViewCommand = new ViewModelCommand(ExecuteShowDashboardViewCommand);
        }
        private void ExecuteShowTrangChuViewCommand(object obj)
        {
            CurrentChildView = new TrangChuViewModel();
        }
        private void ExecuteShowTheLoaiViewCommand(object obj)
        {
            CurrentChildView = new TheLoaiViewModel();
        }
        private void ExecuteShowYourMusicViewCommand(object obj)
        {
            CurrentChildView = new MusicYourVIew();
        }
        private void ExecuteShowDashboardViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
        }
    }
}
