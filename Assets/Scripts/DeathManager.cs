using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public int playerDeaths;

    public static DeathManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        if(SaveManager.Instance.hasLoaded)
        {
            playerDeaths = SaveManager.Instance.activeSave.deaths;
        }
        else
        {
            SaveManager.Instance.activeSave.deaths = playerDeaths;
        }
    }
}
