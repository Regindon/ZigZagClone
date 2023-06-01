using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : Singleton<SaveData>
{
    public PlayerStats playerStats = new PlayerStats();
    
    protected override void Awake()
    {
        LoadFromJson();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/PlayerStatsData.json";
        string playerStatsData = System.IO.File.ReadAllText(filePath);
        playerStats = JsonUtility.FromJson<PlayerStats>(playerStatsData);
    }

    public void SaveToJson()
    {
        string playerStatsData = JsonUtility.ToJson(playerStats);
        string filePath = Application.persistentDataPath + "/PlayerStatsData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath,playerStatsData);
    }

}

[System.Serializable]
public class PlayerStats
{
    public int playerScore;
    public int gameOverPlayerScore;
    public int highScore;
    public int gamesPlayed;
}

