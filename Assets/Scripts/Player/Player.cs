using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _movement;
    private bool _xDirection;
    private bool _move;
    private bool _saved;
    

    void Update()
    {

        if (!_move)
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (!_saved)
            {
                StartCoroutine(Death());
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _move)
        {
            _xDirection = !_xDirection;
            SaveData.Instance.playerStats.playerScore++;
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

    private IEnumerator Death()
    {
        _saved = true;
        if (SaveData.Instance.playerStats.highScore<SaveData.Instance.playerStats.playerScore)
        {
            SaveData.Instance.playerStats.highScore = SaveData.Instance.playerStats.playerScore;
        }
        SaveData.Instance.playerStats.gameOverPlayerScore = SaveData.Instance.playerStats.playerScore;
        SaveData.Instance.playerStats.playerScore = 0;
        SaveData.Instance.playerStats.gamesPlayed++;
        SaveData.Instance.SaveToJson();
        yield return new WaitForSeconds(.5f);
        GameOverUI();
    }

    private void GameOverUI()
    {
        Debug.Log("game over ui");
    }
    
}
