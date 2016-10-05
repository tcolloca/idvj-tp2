using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameOverController : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		score.text = GeneralStats.instance.lastGameStats.coins.ToString();

		List<Achievement> unlocked = GeneralStats.instance.evaluateAchievements ();
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public void PlayAgain() {
		SceneManager.LoadScene ("game");
	}

	public void MainMenu() {
		SceneManager.LoadScene ("menu");
	}
}
