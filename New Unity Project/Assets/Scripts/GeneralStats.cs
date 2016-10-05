using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralStats: MonoBehaviour {

	public static GeneralStats instance;

	private GameStats _lastGameStats;
	public GameStats lastGameStats { get{ return _lastGameStats; }
		set { this._lastGameStats = value;
			maxCoins = Mathf.Max (maxCoins, value.coins);
			totalCoins += value.coins;
			maxEnemiesDefeated = (int) Mathf.Max (maxEnemiesDefeated, value.enemiesDefeated);
			totalEnemiesDefeated += value.enemiesDefeated;
			maxTime = (int) Mathf.Max (maxTime, Mathf.RoundToInt(value.time));
			totalTime += Mathf.RoundToInt(value.time);
		}}
	public int gamesPlayed { get; set; }
	public int maxCoins { get; set; }
	public int totalCoins { get; set; }
	public int maxTime { get; set; }
	public int totalTime { get; set; }
	public int maxEnemiesDefeated { get; set; }
	public int totalEnemiesDefeated { get; set; }
	public List<Achievement> achievements { get; private set; }
	public Material ballMaterial { get; set; }

	public void Awake() {
		if (instance == null) {
			instance = this;
			achievements = new List<Achievement> ();
			ballMaterial = MaterialsRepository.Get ("blue");
			SkinsRepository.addSkin (new Skin(SpriteRepository.Get ("blue"), ballMaterial));
			addAchievements ();
			DontDestroyOnLoad (this.gameObject);
		}
	}

	public void addAchievements () {
		achievements.Add (new OrangeAchievement());
		achievements.Add (new EightBallAchievement ());
		achievements.Add (new OneOfThemAchievement ());
	}

	public Achievement getAchievement (int id) {
		foreach (Achievement achievement in achievements) {
			if (achievement.id == id) {
				return achievement;
			}
		}
		return null;
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
