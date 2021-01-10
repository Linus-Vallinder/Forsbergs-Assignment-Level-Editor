using Grid;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [Header("Save File Name Input")]
    public InputField SaveNameInput;

    [Header("Load File Name Input")]
    public InputField LoadNameInput;

    public void SaveGrid()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + $"/{SaveNameInput.text}.map");

        SaveData data = new SaveData
        {
            GridTiles = GridManager.Instance.GridGenerator.GetGridData(),
            Types = GridManager.Instance.GetTypesData()
        };

        binaryFormatter.Serialize(file, data);
        file.Close();

        Debug.Log($"You have save {SaveNameInput.text} as a map");
    }

    public void LoadGrid()
    {
        if (File.Exists(Application.persistentDataPath + $"/{LoadNameInput.text}.map"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + $"/{LoadNameInput.text}.map", FileMode.Open);

            SaveData data = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();

            GridManager.Instance.GridGenerator.LoadSavedGrid(data.GridTiles);
            GridManager.Instance.LoadTypes(data.Types);

            Debug.Log("Game Data loaded!");
        }
        else
        {
            Debug.LogError("Map does not exist");
        }
    }
}