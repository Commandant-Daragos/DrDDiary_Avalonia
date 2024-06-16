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
    public class InventoryViewModel : ViewModelBase, IUserControlViewModel
    {
        private InventoryView inventoryView;
        private InventoryModel inventoryModel;

        public InventoryViewModel(InventoryView invView, InventoryModel invModel)
        {
            inventoryView = invView;
            inventoryModel = invModel;

            inventoryView.DataContext = this;
        }

        public UserControl GetView()
        {
            return inventoryView;
        }

        public InventoryModel GetInventoryModel()
        {
            return inventoryModel;
        }
    }
}
