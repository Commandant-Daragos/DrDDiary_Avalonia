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
    public class SkillViewModel : ViewModelBase, IUserControlViewModel
    {
        private SkillView skillView;
        private SkillModel skillModel;

        public SkillViewModel(SkillView sView, SkillModel sModel)
        {
            skillView = sView;
            skillModel = sModel;    

            skillView.DataContext = this;
        }

        public UserControl GetView()
        {
            return skillView;
        }

        public SkillModel GetSkillModel()
        {
            return skillModel;
        }  
    }
}
