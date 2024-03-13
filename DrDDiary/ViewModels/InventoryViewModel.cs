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
    public class InventoryViewModel : ViewModelBase, IUserControlViewModel
    {
        private InventoryView inventoryView;

        public InventoryViewModel()
        {
            inventoryView = new InventoryView() { DataContext = this };
        }
        public UserControl GetView()
        {
            return inventoryView;
        }
    }
}
