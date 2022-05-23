using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    Save SaveObjectsInGame(int _levelindex, int _score)
    {
        Save save = new Save();
        save.currentlevel = _levelindex;
        save.score = _score;
        return save;
    }

    public void SaveGame(int _levelindex, int _score)
    {
        Save save = SaveObjectsInGame(_levelindex, _score);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/picker3D.save");
        bf.Serialize(fs, save);
        Debug.Log("Level is saved");
    }

    public Save LoadGameSave()
    {
        if (File.Exists(Application.persistentDataPath + "/Picker3D.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(Application.persistentDataPath + "/Picker3D.save");
            Save save = (Save)bf.Deserialize(fs);
            fs.Close();
            return save;
           
        }
        else 
        {
            Debug.Log("leve doesnt saved");
            return null;
        }
    }

}
