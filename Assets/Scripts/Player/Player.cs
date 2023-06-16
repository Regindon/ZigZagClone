using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private int _materialIndex;
    private Vector3 _movement;
    private bool _xDirection;
    private bool _move = true;
    private bool _saved;
    private bool _checkSpeedColor;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlatformManager platformManager;
    
    
    
    void Update()
    {
        
        if (!uiManager.startGame) return;
        
        var currentScore = SaveData.Instance.playerStats.playerScore;
        if (currentScore%25 ==0 && _checkSpeedColor)
        {
            speed += .5f;
            Debug.Log(speed);
            _checkSpeedColor = false;
            
            if (currentScore !=0)
            {
                platformManager.SetPlatformColor(_materialIndex);
                _materialIndex++;
            }
        }
       
        
        
        if (!_move)
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (!_saved)
            {
                Death();
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _move)
        {
            _xDirection = !_xDirection;
            SaveData.Instance.playerStats.playerScore++;
            _checkSpeedColor = true;
        }
        
        _movement = _xDirection ? new Vector3(-1, 0, 0) : new Vector3(0, 0, 1);
        transform.Translate(_movement * (speed * Time.deltaTime));
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _move = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _move = false;
        }
    }

    private void Death()
    {
        _saved = true;
        if (SaveData.Instance.playerStats.highScore<SaveData.Instance.playerStats.playerScore)
        {
            SaveData.Instance.playerStats.highScore = SaveData.Instance.playerStats.playerScore;
        }
        SaveData.Instance.playerStats.gameOverPlayerScore = SaveData.Instance.playerStats.playerScore;
        SaveData.Instance.playerStats.gamesPlayed++;
        SaveData.Instance.SaveToJson();
        uiManager.ActivateGameOverScreen(1f);
        SaveData.Instance.playerStats.playerScore = 0;
        SaveData.Instance.SaveToJson();
    }

    
    
    
}
