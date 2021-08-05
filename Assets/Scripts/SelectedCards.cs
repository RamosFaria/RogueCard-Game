using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCards : MonoBehaviour
{
    public static SelectedCards Instance;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
