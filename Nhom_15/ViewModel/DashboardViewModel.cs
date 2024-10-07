using Nhom_15.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nhom_15.ViewModel
{
     class DashboardViewModel : ViewModelBase
    {
        private string _tenProduct;
        public string TenProduct
        {
            get { return _tenProduct; }
            set
            {
                _tenProduct = value;
                OnPropertyChanged(nameof(TenProduct));
            }
        }

        private ObservableCollection<TheLoai> _ListTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai
        {
            get { return _ListTheLoai; }
            set
            {
                _ListTheLoai = value;
                OnPropertyChanged(nameof(ListTheLoai));
            }
        }
        public TheLoai SelectedTheLoai
        {
            get { return _selectedTheLoai; }
            set
            {
                _selectedTheLoai = value;
                OnPropertyChanged(nameof(SelectedTheLoai));
            }
        }

        private double _gia;
        public double Gia
        {
            get { return _gia; }
            set
            {
                _gia = value;
                OnPropertyChanged(nameof(Gia));
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
        private string _image;
        private Music _selectedProduct;
        private TheLoai _theloai;
        private TheLoai _selectedTheLoai;
        private bool _isPopupVisible;

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public bool IsPopupVisible
        {
            get { return _isPopupVisible; }
            set
            {
                _isPopupVisible = value;
                OnPropertyChanged(nameof(IsPopupVisible));
            }
        }
        public ICommand ShowCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }
        public DashboardViewModel() {
            List<Music> listmusic = DataProvider.Instance.DB.Musics.ToList();
            ListProducts = new ObservableCollection<Music>(listmusic);
            List<TheLoai> theLoais = DataProvider.Instance.DB.TheLoais.ToList();
            ListTheLoai = new ObservableCollection<TheLoai>(theLoais);

            AddCommand = new ViewModelCommand(AddProduct);
            EditCommand= new ViewModelCommand(EditProduct);
            DeleteCommand = new ViewModelCommand(DeleteProduct);
            ShowCommand = new ViewModelCommand(showEdit);
        }
        private void showEdit(object obj)
        {
            IsPopupVisible=!IsPopupVisible;
        }
        public ObservableCollection<Music> ListProducts { get; }
        private void AddProduct(object obj)
        {
            Music newMusic = new Music
            {
                TenProduct = TenProduct,
                Gia = (decimal)Gia,
                Image = Image,
                TheLoaiId=SelectedTheLoai.TheLoaiId
            };

            DataProvider.Instance.AddMusic(newMusic);
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditProduct(object obj)
        {
            if (SelectedProduct != null)
            {
                TenProduct=SelectedProduct.TenProduct;
                Gia= (double)SelectedProduct.Gia;
                Image=SelectedProduct.Image;
                Music newMusic = new Music
                {
                    TenProduct = TenProduct,
                    Gia = (decimal)Gia,
                    Image = Image,
                    TheLoaiId = SelectedTheLoai.TheLoaiId
                };
                DataProvider.Instance.EditMusic(newMusic);
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (SelectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void DeleteProduct(object obj)
        {
            if (SelectedProduct != null)
            {
                DataProvider.Instance.DeleteMusic(SelectedProduct);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if(SelectedProduct == null)
                {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

    }

}
