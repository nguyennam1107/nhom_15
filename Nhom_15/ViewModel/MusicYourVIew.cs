using Nhom_15.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nhom_15.ViewModel
{
    class MusicYourVIew:ViewModelBase
    {
        public MusicYourVIew() {
            var idArray = DataProvider.Instance.GetIdMusicArray(Thread.CurrentPrincipal.Identity.Name);
            var Details = DataProvider.Instance.GetDetails(idArray);
            YourMusic = new ObservableCollection<Music>(Details);
        }

        public ObservableCollection<Music> YourMusic { get; }
    }
}
