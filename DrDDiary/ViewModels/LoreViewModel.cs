using Avalonia.Controls;
using DrDDiary.Interfaces;
using DrDDiary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.ViewModels
{
    public class LoreViewModel : ViewModelBase, IUserControlViewModel
    {
        private LoreView loreView;

        public LoreViewModel()
        {
            loreView = new LoreView() { DataContext = this };
        }

        public UserControl GetView()
        {
            return loreView;
        }
    }
}
