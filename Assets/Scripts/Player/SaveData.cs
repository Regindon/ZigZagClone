using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int playerScore;

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

    public void SaveToJson()
    {
        string playerScoreData = JsonUtility.ToJson(playerScore);

        string filePath = Application.persistentDataPath + "/PlayerScoreData.json";
        
        Debug.Log(filePath);
        
        System.IO.File.WriteAllText(filePath,playerScoreData);
        Debug.Log("saved");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/PlayerScoreData.json";
        string playerScoreData = System.IO.File.ReadAllText(filePath);

        playerScore = JsonUtility.FromJson<int>(playerScoreData);
    }
}
