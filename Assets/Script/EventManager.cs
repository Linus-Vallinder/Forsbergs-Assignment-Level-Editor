using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tiles;
using Tiles.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
