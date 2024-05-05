﻿using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using DrDDiary.Helpers;
using DrDDiary.Interfaces;
using DrDDiary.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.ViewModels
{
    public class CharacterViewModel : ViewModelBase, IUserControlViewModel
    {
        private CharacterView characterView;
        //private const string IMAGESELECT = "Assets/Images/CharacterScreen/button_selection_character_screen.png";

        public CharacterViewModel()
        {
            SelectCharImageButtonClicked = ReactiveCommand.Create(OpenSelectionWindow);

            characterView = new CharacterView() { DataContext = this };
            LanguageEventHandler.LanguageEvent += ReloadViewLabels;
            //characterView.ButtonSelectionCharacterScreen.Content = new Image { Source = new Bitmap(IMAGESELECT) };
        }

        public UserControl GetView()
        {
            return characterView;
        }

        /// <summary>
        /// Character image button selection
        /// </summary>
        public ReactiveCommand<Unit, Unit> SelectCharImageButtonClicked { get; set; }

        private void OpenSelectionWindow()
        {
            //Process.Start("explorer.exe");
            OpenFileExplorer();
        }

        private void OpenFileExplorer()
        {
            var openFileDialog = new OpenFileDialog();
            //openFileDialog.Title = "Select Image";
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "Images", Extensions = { "jpg", "jpeg", "png", "gif", "bmp" } });

            // Show the file dialog asynchronously
            var task = openFileDialog.ShowAsync(App.MainWindowInstance);

            // Wait for the user to select a file
            task.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully && t.Result.FirstOrDefault() != null)
                {
                    var ImagePath = t.Result.FirstOrDefault(); // Get the first selected file

                    // Perform UI updates from a non-UI thread
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        // Update UI elements here
                        if (ImagePath is not null)
                        {
                            characterView.ButtonSelectionCharacterScreen.Content = new Image { Source = new Bitmap(ImagePath) };
                            characterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                        }
                    });
                }
            });
        }

        private void ReloadViewLabels(object sender, LanguageEvent e)
        {
            characterView.SetLabelContent();
        }
    }
}