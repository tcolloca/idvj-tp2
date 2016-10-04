using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int playerLives = 5;
    private int coinsPicked = 0;

    private Text scoreText;
    private Text livesText;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>();
        scoreText.text = coinsPicked + "";
        livesText.text = playerLives + "";

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CoinPicked()
    {
        Debug.Log("Coin Picked!");
        coinsPicked++;
        scoreText.text = coinsPicked + "";
    }

    public void PlayerDied()
    {
        playerLives--;
        livesText.text = playerLives + "";
        if (playerLives <= 0)
        {
            GameOver();
            return;
        }
    }

    private void GameOver()
    {
        //TODO: go to after-game scene or return to menu
    }
}
