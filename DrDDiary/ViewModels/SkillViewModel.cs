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
    public class SkillViewModel : ViewModelBase, IUserControlViewModel
    {
        private SkillView skillView;

        public SkillViewModel()
        {
            skillView = new SkillView() { DataContext = this };
        }

        public UserControl GetView()
        {
            return skillView;
        }
    }
}
