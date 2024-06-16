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
    public class NotesViewModel : ViewModelBase, IUserControlViewModel
    {
        private NotesView notesView;
        private NotesModel notesModel;

        public NotesViewModel(NotesView nView, NotesModel nModel)
        {
            notesView = nView;
            notesModel = nModel;

            notesView.DataContext = this;
        }

        public UserControl GetView()
        {
            return notesView;
        }

        public NotesModel GetNotesModel()
        {
            return notesModel;
        }
    }
}
