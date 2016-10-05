using UnityEngine;
using System.Collections;

public class StonesAchievement : Achievement {

	private static readonly int ID = Achievement.nextId();
	private static readonly int totalEnemies = 2;
	private static readonly Sprite achieved = SpriteRepository.Get("stone");  
	private static readonly Sprite notAchieved = SpriteRepository.Get("mysterious_ball");  

	public StonesAchievement() : base (achieved, notAchieved, "Rock It!", 
		"Show them that you are way better than them.", 
		string.Format("Make {0} enemies fall into the abyss in one game.", totalEnemies)) {
		id = ID;
	}

	public override bool evaluate (GeneralStats generalStats) {
		if (generalStats.totalEnemiesDefeated >= totalEnemies) {
			return true;
		}
		return false;
	}

	public override void effect() {
		SkinsRepository.addSkin (new Skin(achieved, MaterialsRepository.Get ("stone")));
	}
}

