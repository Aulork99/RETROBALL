using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChange;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Cover);
    }

    public void UpdateGameState(GameState newstate) 
    {
        state = newstate;

        switch (newstate) 
        {
            case GameState.Cover:

                break;
            case GameState.StartGame:

                break;
            case GameState.PlayerMoving:

                break;

            case GameState.BallRolling:
                break;

            case GameState.BallScoring:

                break;
            case GameState.DisplayScore:

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);

        }

        OnGameStateChange?.Invoke(newstate);

    }



}

public enum GameState
{
    Cover,
    StartGame,
    BallRolling,
    PlayerMoving,
    BallScoring,
    DisplayScore

}

