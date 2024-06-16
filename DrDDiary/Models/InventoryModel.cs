using DrDDiary.Interfaces.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Models
{
    [Serializable]
    public class InventoryModel : BaseModel, IInventoryModel
    {
        public InventoryModel()
        {
            
        }
    }
}
