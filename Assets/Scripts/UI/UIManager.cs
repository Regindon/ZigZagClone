using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool startGame;

    [Header("Player Score in Game")] [Space(10)]
    [SerializeField] private TextMeshProUGUI _playerScoreInGame;

    [Header("Start screen UI")]
    [Space(10)]
    
    [Header("GamesPlayedText/HighScoreText/GameName")] 
    public RectTransform highScoreTextPanel; //This should contain highScoreText, gamesPlayedText
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gamesPlayedText;
    [Space(5)]
    
    [Header("GameName/Tap to Play")] 
    public RectTransform gameNameTextPanel; //This should contain gameNameText, tapToPlayText
    [Space(5)]
    
    /*
    [Header("Buttons")] 
    public RectTransform buttonsPanel; //This should contain soundButton, shotButton
    public Button soundButton;
    public Button shopButton;
    */


    [Space(10)] [Header("Game over screen UI")] [Space(10)] [Header("ScoreText/HighScoreText/RetryButton/GameOverText")]
    public RectTransform gameOverScorePanel; //This should contain gameOverText, gameOverPlayerScoreText, gameOverHighScore, retryButton
    public TextMeshProUGUI gameOverPlayerScoreText;
    public TextMeshProUGUI gameOverHighScoreText;


    private void Start()
    {
        ActivateStartScreen(.5f);
    }

    private void Update()
    {
        _playerScoreInGame.text = SaveData.Instance.playerStats.playerScore.ToString();

        if (startGame)
        {
            return;
        }

        if (!Input.GetMouseButtonDown(0)) return;
        startGame = true;
        DeactivateStartScreen(.5f);
    }


    private void ActivateStartScreen(float animationDelay )
    {
        var highScore = SaveData.Instance.playerStats.highScore;
        highScoreText.text += highScore;
        var gamesPlayed = SaveData.Instance.playerStats.gamesPlayed;
        gamesPlayedText.text += gamesPlayed;
        
        gameNameTextPanel.DOAnchorPosY(1200, animationDelay, true);
        highScoreTextPanel.DOAnchorPosY(550, animationDelay, true);
        
    }

    private void DeactivateStartScreen(float animationDelay)
    {
        gameNameTextPanel.DOAnchorPosY(2300, animationDelay, true);
        highScoreTextPanel.DOAnchorPosY(-500, animationDelay, true);
        
    }

    public void ActivateGameOverScreen(float animationDelay)
    {
        var gameOverPlayerScore = SaveData.Instance.playerStats.gameOverPlayerScore;
        gameOverPlayerScoreText.text += gameOverPlayerScore;
        var gameOverHighScore = SaveData.Instance.playerStats.highScore;
        gameOverHighScoreText.text += gameOverHighScore;
        
        gameOverScorePanel.DOAnchorPosX(0, animationDelay, true);
    }

    
    /*
    public void DeactivateGameOverScreen(float animationDelay)
    {
        gameOverScorePanel.DOAnchorPosX(800, animationDelay, true);
    }
    */

}
