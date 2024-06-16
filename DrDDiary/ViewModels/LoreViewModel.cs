using Avalonia.Controls;
using DrDDiary.Interfaces;
using DrDDiary.Models;
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
        private LoreModel loreModel;

        public LoreViewModel(LoreView lView, LoreModel lModel)
        {
            loreView = lView;
            loreModel = lModel;

            loreView.DataContext = this;
        }

        public UserControl GetView()
        {
            return loreView;
        }

        public LoreModel GetLoreModel()
        {
            return loreModel;
        }
    }
}
