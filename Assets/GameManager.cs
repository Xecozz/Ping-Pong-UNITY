using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")] public GameObject ball;

    [Header("Player 1")] public GameObject player1Paddle;

    [Header("Player 2")] public GameObject player2Paddle;

    [Header("Score UI")] public GameObject player1Text;
    public GameObject player2Text;

    [Header("Button")] public GameObject buttonRetry;

    public GameObject buttonQuit;


    [Header("Score")] public int score = 3;

    private int player1Score;
    private int player2Score;
    private bool enableButton = false;

    public void Player1Scored()
    {
        player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();

        if (player1Score >= score)
        {
            ButtonEnabled();
            Time.timeScale = 0;
            player1Text.GetComponent<TextMeshProUGUI>().text = "Win!";
            player2Text.GetComponent<TextMeshProUGUI>().text = "Lose!";
        }

        ResetPosition();
    }

    public void Player2Scored()
    {
        player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();

        if (player2Score >= score)
        {
            ButtonEnabled();
            Time.timeScale = 0;
            player1Text.GetComponent<TextMeshProUGUI>().text = "Lose!";
            player2Text.GetComponent<TextMeshProUGUI>().text = "Win!";
        }

        ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    public void Retry()
    {
        Debug.Log("Retry");

        player1Score = 0;
        player2Score = 0;

        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();

        ButtonEnabled();

        Time.timeScale = 1;
    }

    public void Quit()
    {
        Debug.Log("Quit");

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        
        #endif
        Application.Quit();
    }

    private void ButtonEnabled()
    {
        enableButton = !enableButton;
        buttonRetry.SetActive(enableButton);
        buttonQuit.SetActive(enableButton);
    }
}