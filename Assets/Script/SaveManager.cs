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

    public void SaveGrid()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath
                         + $"/{SaveNameInput.text}.map");

        SaveData data = new SaveData
        {
            GridX = GridManager.Instance.GridGenerator.GridX,
            GridY = GridManager.Instance.GridGenerator.GridY,

            GridTiles = GridManager.Instance.GridGenerator.GetGridData()
        };

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
}
