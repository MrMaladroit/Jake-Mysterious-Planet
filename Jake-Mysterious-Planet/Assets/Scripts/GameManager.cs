using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    public int collectedCoins = 0;

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
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()  
    {
        SetGameState(GameState.gameOver);

    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void CollectedCoin()
    {
        collectedCoins++;
    }

    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if(newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if(newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        currentGameState = newGameState;
    }
}