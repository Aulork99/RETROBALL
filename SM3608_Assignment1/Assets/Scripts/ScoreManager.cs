using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public TMP_Text text;


    void Awake()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;

    }

    private void GameManager_OnGameStateChange(GameState state)
    {
        if (state == GameState.BallRolling) { text.text = " "; }

        if (state == GameState.DisplayScore)
        {
            text.text = score.ToString();
            GameManager.Instance.UpdateGameState(GameState.StartGame);
        }

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }
}
