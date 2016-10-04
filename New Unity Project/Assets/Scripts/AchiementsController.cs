using UnityEngine;
using System.Collections;

public class AchiementsController : MonoBehaviour {

	List<Achievement> achievements; 

	// Use this for initialization
	void Start () {
		achievements = GameStats.instance.achievements;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
