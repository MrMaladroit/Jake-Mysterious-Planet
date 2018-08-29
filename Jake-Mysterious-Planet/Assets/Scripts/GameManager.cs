using UnityEngine;
using System.Collections;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        if(Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    public void GameOver()  
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            currentGameState = GameState.menu;
        }
        else if(newGameState == GameState.inGame)
        {
            currentGameState = GameState.inGame;
        }
        else if(newGameState == GameState.gameOver)
        {
            currentGameState = GameState.gameOver;
        }
    }
}