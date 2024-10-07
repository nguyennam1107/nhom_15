using Nhom_15.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Nhom_15.ViewModel
{
     class TheLoaiViewModel:ViewModelBase
    {
        private Music _selectedProduct;
        private TheLoai _theloai;
        private bool _isPopupVisible;
        private ICollectionView _groupedProductsView;

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

        public ICollectionView GroupedProductsView
        {
            get { return _groupedProductsView; }
            set
            {
                _groupedProductsView = value;
                OnPropertyChanged(nameof(GroupedProductsView));
            }
        }

        public ObservableCollection<Music> ListProducts { get; }
        public ObservableCollection<TheLoai> ListTheLoai { get; }

        public TheLoaiViewModel()
        {
            List<Music> listmusic = DataProvider.Instance.DB.Musics.ToList();
            ListProducts = new ObservableCollection<Music>(listmusic);
            List<TheLoai> theLoais=DataProvider.Instance.DB.TheLoais.ToList();
            ListTheLoai = new ObservableCollection<TheLoai>(theLoais);
            var collectionViewSource = new CollectionViewSource { Source = ListProducts };
            collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription("TheLoaiId", new TheLoaiIdToTenTheLoaiConverter(ListTheLoai)));

            GroupedProductsView = collectionViewSource.View;
        }
    }
    public class TheLoaiIdToTenTheLoaiConverter : IValueConverter
    {
        private readonly ObservableCollection<TheLoai> _listTheLoai;

        public TheLoaiIdToTenTheLoaiConverter(ObservableCollection<TheLoai> listTheLoai)
        {
            _listTheLoai = listTheLoai;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int theLoaiId)
            {
                var theLoai = _listTheLoai.FirstOrDefault(t => t.TheLoaiId == theLoaiId);
                return theLoai?.TenTheLoai;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
