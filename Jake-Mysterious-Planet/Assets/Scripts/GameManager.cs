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
    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
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

        }
        else if(newGameState == GameState.inGame)
        {

        }
        else if(newGameState == GameState.gameOver)
        {
            
        }
    }
}