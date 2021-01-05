using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEditorUIManager : MonoBehaviour
{
    public void CenterCamera()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
}
