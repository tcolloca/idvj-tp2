using System;
using UnityEngine;

public class EightBallAchievement : Achievement {

	private static readonly Sprite achieved = SpriteRepository.Get("eight_ball");  
	private static readonly Sprite notAchieved = SpriteRepository.Get("mysterious_ball");  

	public EightBallAchievement() : base (achieved, notAchieved, "Don't Sink The Ball!", "8", "Collect 8 coins in one game.") {
	}

	// TODO
	public override bool evaluate (GeneralStats generalStats) {
		if (generalStats.lastGameStats.coins == 0) {
			return true;
		}
		return false;
	}
}

