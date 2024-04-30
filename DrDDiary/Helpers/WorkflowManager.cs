using Avalonia.Controls;
using DrDDiary.Interfaces;
using DrDDiary.ViewModels;
using DrDDiary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Helpers
{
    /// <summary>
    /// Marked Obsolete-functionality used before DI was implemented.
    /// Class was used as workflow manager for views and viewmodels.
    /// </summary>
    public static class WorkflowManager
    {
        private static Dictionary<string, IUserControlViewModel> views = new Dictionary<string, IUserControlViewModel>();

        public static MainWindowViewModel mainWindowViewModel { get; set; }

        public static UserControl GetView(string nameOfView)
        {
            return views[nameOfView].GetView();
        }

        public static void CreateViewModels()
        {
            views.Add("CharacterUC",new CharacterViewModel());
            views.Add("InventoryUC", new InventoryViewModel());
            views.Add("SkillUC", new SkillViewModel());
            views.Add("LoreUC", new LoreViewModel());
            views.Add("NotesUC", new NotesViewModel());
        }

        public static void CreateMainViewModel()
        {
            views.Add("MainUC", new MainViewModel());
        }
    }
}
