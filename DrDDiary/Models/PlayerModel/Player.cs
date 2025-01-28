using DrDDiary.Interfaces.PlayerInterfaces;
using DrDDiary.ViewModels;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Models.PlayerModel
{
    [ProtoContract]
    public class Player
    {
        [ProtoMember(1)]
        public CharacterModel CharacterModel { get; set; }
        //[ProtoMember(2)]
        //public InventoryModel InventoryModel { get; set; }
        //[ProtoMember(3)]
        //public SkillModel SkillModel { get; set; }
        //[ProtoMember(4)]
        //public LoreModel LoreModel { get; set; }
        //[ProtoMember(5)]
        //public NotesModel NotesModel { get; set; }

        public Player(CharacterModel characterModel, InventoryModel inventoryModel, SkillModel skillModel, LoreModel loreModel, NotesModel notesModel)
        {
            CharacterModel = characterModel;
            //InventoryModel = inventoryModel;
            //SkillModel = skillModel;
            //LoreModel = loreModel;
            //NotesModel = notesModel;
        }

        // Parameterless constructor for serialization, is needed ?
        public Player() { }
    }
}
