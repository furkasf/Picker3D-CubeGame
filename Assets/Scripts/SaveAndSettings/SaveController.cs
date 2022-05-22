using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] Transform levelContainer;
    [SerializeField] Transform player;
    [SerializeField] GameObject score;

    Save SaveObjectsInGame()
    {
        Save save = new Save();
        save.level = levelContainer;
        save.Player = player;
        return save;
    }

    public void SaveGame()
    {
        Save save = SaveObjectsInGame();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/picker3D.save");
        bf.Serialize(fs, save);
        Debug.Log("Level is saved");
    }

    public void LoadGame()
    {
        RsesetCurrentGame();
        if (File.Exists(Application.persistentDataPath + "/Picker3D.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(Application.persistentDataPath + "/Picker3D.save");
            Save save = (Save)bf.Deserialize(fs);
            fs.Close();
            player = save.Player;
            levelContainer = save.level;
            Debug.Log("save File is loaded");
        }
        else 
        {
            Debug.Log("leve doesnt saved");
        }
    }

    void RsesetCurrentGame()
    {
        Destroy(levelContainer.GetChild(0));
        Destroy(player.gameObject);
    }

}
