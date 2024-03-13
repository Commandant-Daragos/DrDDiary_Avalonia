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
    public class NotesViewModel : ViewModelBase, IUserControlViewModel
    {
        private NotesView notesView;

        public NotesViewModel()
        {
            notesView = new NotesView() { DataContext = this };
        }

        public UserControl GetView()
        {
            return notesView;
        }
    }
}
