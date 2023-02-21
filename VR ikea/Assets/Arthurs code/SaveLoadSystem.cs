using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem
{

    public static void SavePlayer(TestPlayer player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);


        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPLayer() {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path)) {
            return null;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
