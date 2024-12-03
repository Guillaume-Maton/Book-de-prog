using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    [SerializeField] private Ruby br;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        br.rubyCount = PlayerPrefs.GetInt("rubyCount", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("rubyCount", br.rubyCount);
    }
}