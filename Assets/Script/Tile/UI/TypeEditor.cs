using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Grid;
using Tiles;
using System;

public class TypeEditor : MonoBehaviour
{
    public InputField NameInput;

    [Space]
    public Slider Red, Green, Blue;

    [Space]
    public Image ColorPreview;

    private void Update()
    {
        if (GridManager.Instance.TypeSelector.SelectedType == null)
        {
            return;
        }

        EditType(GridManager.Instance.TypeSelector.SelectedType);
    }

    private void EditType(TileType type)
    {
        ColorPreview.color = new Color(Red.value, Green.value, Blue.value, 1);
    }

    public void SetType()
    {
        var type = GridManager.Instance.TypeSelector.SelectedType;

        if (type != null)
        {
            type.Color = new Color(Red.value, Green.value, Blue.value, 1);

            type.Name = NameInput.text;
            type.name = NameInput.text;
        }

        GridManager.Instance.GridGenerator.ReloadGridColor();
    }

    public void SetupTypeEditor()
    {
        var type = GridManager.Instance.TypeSelector.SelectedType;

        if (type != null)
        {
            ColorPreview.color = type.Color;

            Red.value = type.Color.r;
            Green.value = type.Color.g;
            Blue.value = type.Color.b;

            NameInput.text = type.Name;
        }
    }
}
