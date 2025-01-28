using Avalonia.Media.Imaging;
using DrDDiary.Helpers.ValueConverter;
using DrDDiary.Helpers.ValueConverter.BitMapSurrogate;
using DrDDiary.Models.PlayerModel;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProtoBuf.Meta;
using ProtoBuf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DrDDiary.Serializer
{
    public static class PlayerStorage
    {
        //need to be defined as basic path, and during saving, part with CharacterName.json is added
        //private const string FilePath = "playerData.json"; //filepath=C:\Program Files (x86)\Default Company Name - basic root path + \Saved characters +\CharacterName.json

        public static async Task SavePlayerAsync(Player player)
        {
            var fileName = string.IsNullOrWhiteSpace(player.CharacterModel.Name)
                   ? "defaultCharacterName.bin"
                    : player.CharacterModel.Name + ".bin";

            using (var file = File.Create(fileName))
            {
                ProtoBuf.Serializer.Serialize(file, player);
            }


            //    var options = new JsonSerializerOptions
            //    {
            //        WriteIndented = true,
            //        // This is important for deserializing interfaces back to concrete types
            //        Converters = {
            //                       new JsonStringEnumConverter(),
            //                       new ImageConverter()
            //                     }
            //    };

            //    var json = JsonSerializer.Serialize(player, options);
            //    //await File.WriteAllTextAsync(player.CharacterModel.NameTextBoxValue + ".json", json);
            //    var fileName = string.IsNullOrWhiteSpace(player.CharacterModel.Name)
            //        ? "defaultCharacterName.json"
            //        : player.CharacterModel.Name + ".json";

            //    await File.WriteAllTextAsync(fileName, json);
        }

        //public static async Task<Player> LoadPlayerAsync()
        //{
        //    if (!File.Exists("Alibaba.json"))
        //    {
        //        throw new FileNotFoundException("Player data file not found.");
        //    }

        //    var json = await File.ReadAllTextAsync("Alibaba.json");
        //    var options = new JsonSerializerOptions
        //    {
        //        Converters = {
        //                       new JsonStringEnumConverter(),
        //                       new ImageConverter()
        //                     }
        //    };

        //    return JsonSerializer.Deserialize<Player>(json, options);
        //}

        // Load Player Data from file
        public static async Task<Player> LoadPlayerAsync()
        {
            // Check if the file exists
            if (!File.Exists("Alibaba.bin"))
            {
                throw new FileNotFoundException("Player data file not found.");
            }


            // Deserialize the player object from the file
            using (var file = File.OpenRead("Alibaba.bin"))
            {
                return ProtoBuf.Serializer.Deserialize<Player>(file);
            }
        }
    }
}
