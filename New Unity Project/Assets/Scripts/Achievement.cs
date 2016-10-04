using UnityEngine;
using System.Collections;

public class Achievement {

	public Sprite image { get; private set; }
	public string title { get; private set; }
	public string description { get; private set; }
	public bool isAchieved { get; private set; } = false; 
	
	public Achievement (Sprite image, string title, string description) {
		this.image = image;
		this.title = title;
		this.description = description;
	}
}
