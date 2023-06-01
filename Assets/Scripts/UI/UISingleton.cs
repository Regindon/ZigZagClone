using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISingleton : Singleton<UISingleton>
{
    [Header("Start screen UI")]
    [Space(10)]
    
    [Header("GamesPlayedText/HighScoreText/GameName")] 
    public RectTransform highScoreTextPanel; //This should contain highScoreText, gamesPlayedText
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gamesPlayedText;
    [Space(5)]
    
    [Header("GameName/Tap to Play")] 
    public RectTransform gameNameTextPanel; //This should contain gameNameText, tapToPlayText
    public TextMeshProUGUI gameNameText;
    public TextMeshProUGUI tapToPlayText;
    [Space(5)]
    
    [Header("Buttons")] 
    public RectTransform buttonsPanel; //This should contain soundButton, shotButton
    public Button soundButton;
    public Button shopButton;

    [Space(10)] [Header("Game over screen UI")] [Space(10)] [Header("ScoreText/HighScoreText/RetryButton/GameOverText")]
    public RectTransform gameOverScorePanel; //This should contain gameOverText, gameOverPlayerScoreText, gameOverHighScore, retryButton
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverPlayerScoreText;
    public TextMeshProUGUI gameOverHighScoreText;
    public Button retryButton;


    public void ActivateStartScreen(float animationDelay , string _highScoreText, string _gamesPlayedText )
    {
        int highScore = SaveData.Instance.playerStats.highScore;
        highScoreText.text += highScore;
        int gamesPlayed = SaveData.Instance.playerStats.gamesPlayed;
        gamesPlayedText.text += gamesPlayed;
        
        gameNameTextPanel.DOAnchorPosY(100, animationDelay, true);
        highScoreTextPanel.DOAnchorPosY(80, animationDelay, true);
        buttonsPanel.DOAnchorPosY(60, animationDelay, true);
    }

    public void DeactivateStartScreen(float animationDelay)
    {
        gameNameTextPanel.DOAnchorPosY(-100, animationDelay, true);
        highScoreTextPanel.DOAnchorPosY(-100, animationDelay, true);
        buttonsPanel.DOAnchorPosY(-100, animationDelay, true);
    }

    public void ActivateGameOverScreen(float animationDelay)
    {
        int gameOverPlayerScore = SaveData.Instance.playerStats.gameOverPlayerScore;
        gameOverPlayerScoreText.text += gameOverPlayerScore;
        int gameOverHighScore = SaveData.Instance.playerStats.highScore;
        gameOverHighScoreText.text += gameOverHighScore;
        
        gameOverScorePanel.DOAnchorPosY(100, animationDelay, true);
    }

    public void DeactivateGameOverScreen(float animationDelay)
    {
        gameOverScorePanel.DOAnchorPosY(-100, animationDelay, true);
    }

}
