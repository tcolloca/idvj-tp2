using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStats: MonoBehaviour {

	public static GameStats instance;

	public int gamesPlayed { get; set; }
	public int maxScore { get; set; }
	public List<Achievement> achievements { get; private set; }

	public void Awake() {
		instance = this;
		achievements = new List<Achievement> ();
		addAchievements ();
		DontDestroyOnLoad (this.gameObject);
	}

	public void addAchievements () {
		addAchievement (null, "Lala", "LALALALALALA!");
		addAchievement (null, "Puto", "PUATAAAAAAAAA!");
	}

	private void addAchievement (Sprite image, string title, string description) {
		achievements.Add (new Achievement(image, title, description));
	}
}
