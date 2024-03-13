﻿using Avalonia.Controls;
using DrDDiary.Interfaces;
using DrDDiary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.ViewModels
{
    public class CharacterViewModel : ViewModelBase, IUserControlViewModel
    {
        private CharacterView characterView;

        public CharacterViewModel()
        {
            characterView = new CharacterView() { DataContext = this };
        }

        public UserControl GetView()
        {
            return characterView;
        }
    }
}
