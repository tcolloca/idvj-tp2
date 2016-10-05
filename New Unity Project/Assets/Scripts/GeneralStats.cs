using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralStats: MonoBehaviour {

	public static GeneralStats instance;

	public GameStats lastGameStats { get; set; }
	public int gamesPlayed { get; set; }
	public int maxScore { get; set; }
	public List<Achievement> achievements { get; private set; }

	public void Awake() {
		if (instance == null) {
			instance = this;
			achievements = new List<Achievement> ();
			addAchievements ();
			DontDestroyOnLoad (this.gameObject);
		}
	}

	public void addAchievements () {
		achievements.Add (new EightBallAchievement());
	}

	public List<Achievement> evaluateAchievements () {
		List<Achievement> unlocked = new List<Achievement> ();
		foreach (Achievement achievement in achievements) {
			if (!achievement.isAchieved && achievement.evaluate(this)) {
				unlocked.Add (achievement);
				achievement.achieve ();
			}
		}
		return unlocked;
	}
}
