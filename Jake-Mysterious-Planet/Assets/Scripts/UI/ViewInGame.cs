using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    private void Update()
    {
        if(GameManager.instance.currentGameState == GameState.inGame)
        {
            coinsLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            highScoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}