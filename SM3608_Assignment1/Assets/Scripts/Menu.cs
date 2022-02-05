using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Canvas menu;
    private void Awake()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
        Cursor.visible = false;
    }

    private void GameManager_OnGameStateChange(GameState state)
    {
        menu.enabled = state == GameState.Cover;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) GameManager.Instance.UpdateGameState(GameState.StartGame);
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
