using Nhom_15.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhom_15.ViewModel
{
    internal class TrangChuViewModel:ViewModelBase
    {
        private bool _isPopupVisible;
        private Music _selectedProduct;
        private TheLoai _theloai;

        public ICommand ClosePopupCommand { get; }
        public ICommand BuyCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ObservableCollection<Music> ListProducts { get; set; }
        public bool IsPopupVisible
        {
            get { return _isPopupVisible; }
            set
            {
                _isPopupVisible = value;
                OnPropertyChanged(nameof(IsPopupVisible));
            }
        }
        public Music SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                if (SelectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                    TheLoai = DataProvider.Instance.DB.TheLoais.FirstOrDefault(u => u.TheLoaiId == SelectedProduct.TheLoaiId);
                    IsPopupVisible = true;
                }
            }
        }
        public TheLoai TheLoai
        {
            get
            {
                return _theloai;
            }
            set
            {
                if (TheLoai != value)
                {
                    _theloai = value;
                    OnPropertyChanged(nameof(TheLoai));
                }
            }
        }
        private void AddToCart(object obj)
        {
            TaiKhoan taiKhoan = DataProvider.Instance.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            var music = new MusicYour
            {
                IdProduct = SelectedProduct.IdProduct,
                TenDangNhap = taiKhoan.TenDangNhap,
                NgayMua = DateTime.Now,
            };
            DataProvider.Instance.Addmusic(music);
            MessageBox.Show("Thêm vào thư viện thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ClosePopup(object obj)
        {
            IsPopupVisible = false;
        }
        public TrangChuViewModel() {
            List<Music> listmusic = DataProvider.Instance.DB.Musics.ToList();
            ListProducts = new ObservableCollection<Music>(listmusic);
            ClosePopupCommand = new ViewModelCommand(ClosePopup);
            //BuyCommand = new ViewModelCommand(ExecuteShowBuyViewCommand);
            AddToCartCommand = new ViewModelCommand(AddToCart);
        }
    }
}
