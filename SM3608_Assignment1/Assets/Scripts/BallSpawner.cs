using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public Vector3 pos;


    void Awake()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;

    }

    private void GameManager_OnGameStateChange(GameState state)
    {
        if (state == GameState.StartGame) 
        {
            Instantiate(ball, pos, Quaternion.identity);
            GameManager.Instance.UpdateGameState(GameState.PlayerMoving);
        }

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }
}
