using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public InputField SaveNameInput;

    [Space]
    public InputField LoadNameInput;

    public void SaveGrid()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath
                         + $"/{SaveNameInput.text}.map");

        SaveData data = new SaveData
        {
            GridTiles = GridManager.Instance.GridGenerator.GetGridData()
        };

        bf.Serialize(file, data);
        file.Close();
        Debug.Log($"You have save {SaveNameInput.text} as a map");
    }

    public void LoadGrid()
    {
        if (File.Exists(Application.persistentDataPath + $"/{LoadNameInput.text}.map"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + $"/{LoadNameInput.text}.map", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            GridManager.Instance.GridGenerator.LoadSavedGrid(data.GridTiles);

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("Map does not exist");
    }
}
